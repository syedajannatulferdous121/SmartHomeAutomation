using System;

class SmartHomeAutomation
{
    interface IDevice
    {
        void TurnOn();
        void TurnOff();
    }

    class Light : IDevice
    {
        public bool IsOn { get; set; }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine("Light turned on.");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine("Light turned off.");
        }
    }

    class Thermostat : IDevice
    {
        public int Temperature { get; set; }

        public void TurnOn()
        {
            Console.WriteLine("Thermostat turned on.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Thermostat turned off.");
        }

        public void SetTemperature(int temperature)
        {
            Temperature = temperature;
            Console.WriteLine($"Temperature set to {temperature}°C.");
        }
    }

    class SmartHome
    {
        private IDevice[] devices;

        public SmartHome()
        {
            devices = new IDevice[]
            {
                new Light(),
                new Thermostat()
            };
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Smart Home Automation!");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Turn device on");
                Console.WriteLine("2. Turn device off");
                Console.WriteLine("3. Set thermostat temperature");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Select a device:");
                        for (int i = 0; i < devices.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {devices[i].GetType().Name}");
                        }
                        int deviceChoice = int.Parse(Console.ReadLine()) - 1;

                        if (deviceChoice >= 0 && deviceChoice < devices.Length)
                        {
                            devices[deviceChoice].TurnOn();
                        }
                        else
                        {
                            Console.WriteLine("Invalid device choice.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Select a device:");
                        for (int i = 0; i < devices.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {devices[i].GetType().Name}");
                        }
                        int deviceChoice2 = int.Parse(Console.ReadLine()) - 1;

                        if (deviceChoice2 >= 0 && deviceChoice2 < devices.Length)
                        {
                            devices[deviceChoice2].TurnOff();
                        }
                        else
                        {
                            Console.WriteLine("Invalid device choice.");
                        }
                        break;

                    case 3:
                        if (devices[1] is Thermostat thermostat)
                        {
                            Console.WriteLine("Enter the temperature:");
                            int temperature = int.Parse(Console.ReadLine());
                            thermostat.SetTemperature(temperature);
                        }
                        else
                        {
                            Console.WriteLine("Thermostat is not available.");
                        }
                        break;

                    case 4:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Smart Home Automation program has ended.");
        }
    }

    static void Main(string[] args)
    {
        SmartHome smartHome = new SmartHome();
        smartHome.Run();
    }
}

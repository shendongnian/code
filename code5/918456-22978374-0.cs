    class MainClass
    {
        static void Main(string[] args)
        {
            int value;
            bool run;
        
            run = true;
            while(run)
            {
                Console.WriteLine("Calculator Menu");
                Console.WriteLine("1: Compute Volume of a Sphere");
                Console.WriteLine("2: Compute Something else");
                Console.WriteLine("etc,etc,etc");
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    switch (value)
                    {
                        case 1:
                            VolumeSphere Sphere = new VolumeSphere();
                            Sphere.Details();
                            Console.WriteLine(Sphere.GetVolume());
                            Sphere.Display();
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        default:
                            Console.WriteLine("GoodBye");
                            run = false;
                            break;
                    }
                }
            }
            Console.WriteLine("Press Any Key to Exit");
            Console.ReadLine();
        }
    }

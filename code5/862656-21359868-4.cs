            int ch = Console.Read();
            Console.ReadLine();//Add this line to complete reading of a character
            Console.WriteLine("Enter a random integer");
            int x = int.Parse(Console.ReadLine());
           switch (ch)
            {
                case '1':
                    TempServiceRef.Service1Client s1 = new ConsoleTempApplication.TempServiceRef.Service1Client();
                    Console.WriteLine("Enter temperature");
                    string n = Console.ReadLine();
                    int param = int.Parse(n);
                    double result = s1.c2f(param);
                    Console.WriteLine(result);
                    Console.ReadLine();
                    break;
                case '2':
                    TempServiceRef.Service1Client s2 = new ConsoleTempApplication.TempServiceRef.Service1Client();
                    Console.WriteLine("Enter temperature");
                    int param1 = int.Parse(Console.ReadLine());
                    double result1 = s2.f2c(param1);
                    Console.WriteLine(result1);
                    Console.ReadLine();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }

    Console.WriteLine("Enter Something From Keybord");
            var variable = Console.ReadLine();
    
            switch (variable.GetType())
            {
                case typeof(int):
                           variable += 1;
                           Console.WriteLine(variable);
                    break;
                case typeof(string):
                            variable +="*";
                            Console.WriteLine(variable);
                            break;
                case typeof(double):
                            variable += 1;
                            Console.WriteLine(variable);
                            break;
                default:
                    break;
            }

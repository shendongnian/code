    string input;
                    input= Console.ReadLine();
                    int numberArg;
                    while (!int.TryParse(input, out numberArg))
                    {
                        Console.WriteLine(@"Wrong parameter. Type again.");
                        input= Console.ReadLine();
                    }
    
                    var result1 = formula(numberArg);
                    Console.WriteLine("the result is {0}", result1);
                    Console.ReadKey();

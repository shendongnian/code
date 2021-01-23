    namespace ELIZA
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<string, string> questionDict = //creating dictionary for questions and animals
                    new Dictionary<string, string>();
                questionDict.Add("Does it have whiskers?", "cat");
                questionDict.Add("Does it purr?", "cat");
                questionDict.Add("Does it bark?", "dog");
                String lastAnswer="";
                bool isFirstQuestion=true;
    
                foreach (string test in questionDict.Keys)
                {
                    if(isFirstQuestion)
                    {
                        Console.WriteLine("{0}", test);
                        Console.ReadLine();
                        isFirstQuestion=false;
                    }
                    else
                    {
                        if (lastAnswer == "yes")
                        {
                            Console.WriteLine("{0}", test);
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("AW NAW");
                            Console.ReadLine();
                        }
                    }
                    lastAnswer = Console.ReadLine();
                    
                    
                }
            }
        }
    }

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
                foreach (KeyValuePair<string, string> kvp in questionDict)
                {
                    Console.WriteLine("{0}", kvp.Key);
                    string userInput = Console.ReadLine();
                    if (userInput == "yes")
                    {
                        Console.WriteLine("{0}", kvp.Value);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }

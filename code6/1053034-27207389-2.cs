    namespace Skyper.plugins
    {
        public static class Help
        {
            public static string Description
            {
                get 
                {
                    return "Random Object Test";
                }
            }
            public static void Execute(string[] Params, int chat, string username)
            {
                List<string> List1 = new List<string>() {"Pie1", "Pie2"};
                Random rnd = new Random();
                string randomFruit = List1[rnd.Next(0, List1.Count)];
                Skyper.SendMessage(chat, randomFruit);
            }
        }
    }

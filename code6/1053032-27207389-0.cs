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
                List = new List("Pie1", "Pie2");
                Dim rnd as new Random();
                Dim randomFruit = List(rnd.Next(0, List1.Count));
                Skyper.SendMessage(chat, randomFruit);
            }
        }
    }

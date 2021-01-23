    namespace MyApp
    {
        // Every method (function) must be in a class
        class MyProgram
        {
            // This is where code execution begins
            static void Main()
            {
                Console.WriteLine("Hello, world!");
                string playerName = GetPlayerName();
            }
            static string GetPlayerName()
            {
                Console.WriteLine("Some cliche narrative here. Name?");
                return Console.ReadLine();
            }
            // We can also make nested class/struct/enum definitions that are
            // "private" to the containing class.
            private enum APrivateEnum { Foo, Bar }
        }
        enum Race { Human, Orc, Goblin, Undead }
    }

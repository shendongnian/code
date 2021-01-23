    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            string text = File.ReadAllText("foo.txt");
            foreach (char c in text)
            {
                Console.WriteLine("{0} - {1:x4}", c, (int) c);
            }
        }
    }

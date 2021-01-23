    class TestStringSplit
    {
        static void Main()
        {
            char[] delimiterChars = { '\r', '\n', '\t' };
    
            string text = "\r\n\t\StaticWord1:\r\n\t\t2014-05-20 11:03\r\n\t\StaticWord2\r\n\t\t\r\n\t\t\r\n\t\t\t\r\n\t\t\t\r\n\t\t\t\t\t\t\t\t\tWordC WordD\r\n\t\t\t\t\t\t\t\t\r\n\t\t\r\n\t\t\r\n\t\t\r\n\t";
            System.Console.WriteLine("Original text: '{0}'", text);
    
            string[] words = text.Split(delimiterChars);
            System.Console.WriteLine("{0} words in text:", words.Length);
    
            foreach (string s in words)
            {
                System.Console.WriteLine(s);
            }
    
            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }

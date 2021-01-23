    using System;
    
    public class Test
    {
        public static void Main()
        {
            string[] stringArray = { "Nathan", "Bob", "Tom" };
            bool[] matches = new bool[stringArray.Length];
            string searchTerm = "Bob";
            for (int i = 1; i <= stringArray.Length; i++)
            {
                if (searchTerm == stringArray[i - 1])
                {
                    matches[i - 1] = true;
                }
            }
            for (int i = 1; i <= stringArray.Length; i++)
            {
                if (matches[i - 1])
                {
                    Console.WriteLine("We found another " + stringArray[i - 1]);
                }
            }
        }
    }

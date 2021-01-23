        static void Main(string[] args)
        {
            string s = "Take Chocolate";
            string searchString = "cola";
            int beginIndex = 0;
            int endIndex = 0;
            if (s.Contains(searchString))
            {
                beginIndex = s.IndexOf(searchString, 0, s.Length);
                endIndex = beginIndex + searchString.Length;
            }
            if(endIndex < s.Length)
            {
                Console.WriteLine(s[endIndex + 1]);
            }
            else
            {
                Console.WriteLine("There is no character after" + searchString);
            }
            
            if(beginIndex > 0)
                Console.WriteLine(s[beginIndex - 1]);
            else
                Console.WriteLine("There is no character before" + searchString);
        }

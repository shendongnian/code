        public static List<string> Dict = new List<string> { "details", "airline", "all", "get" };
        static void Main(string[] args)
        {
            String s = "getallairlinedetails";
            Console.WriteLine(ReturnSplitString(s));
            Console.ReadLine();
        }
        public static string ReturnSplitString(string s)
        {
            string[] ww = new string[s.Length];
            foreach (string word in Dict)
            {
                if (s.Contains(word))
                {
                    int ind = s.IndexOf(word);
                    ww[ind] = word;
                }
            }
            string sf = "";
            foreach (string sr in ww)
            {
                if (sr != null)
                    sf += sr + " ";
            }
            return sf.TrimEnd(' ');
        }

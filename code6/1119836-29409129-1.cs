    static class StringExtensions
    {
        private static char open = '[';
        private static char close = ']';
        public static string[] Brackets(this string str)
        {
            //Set up vars
            StringBuilder[] builders = new StringBuilder[str.Count(x => x == open)];
            for (int h = 0; h < builders.Count(); h++)
                builders[h] = new StringBuilder();
            string[] results = new string[builders.Count()];
            bool[] tracker = new bool[builders.Count()];
            int haveOpen = 0;
            //loop up string
            for (int i = 0; i < str.Length; i++)
            {
                //if opening bracket
                if (str[i] == open)
                    tracker[haveOpen++] = true;
                //loop over tracker
                for (int j = 0; j < tracker.Length; j++)
                    if (tracker[j])
                        //if in this bracket append to the string
                        builders[j].Append(str[i]);
                //if closing bracket
                if (str[i] == close)
                    tracker[Array.FindLastIndex<bool>(tracker, p => p == true)] = false;
            }
            for (int i = 0; i < builders.Length; i++)
                results[i] = builders[i].ToString();
            return results;
        }
    }

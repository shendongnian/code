        public static string FormatOpt(this string s, string optional, params string[] param)
        {
            StringBuilder result = new StringBuilder();
            int index = 0;
            bool opened = false;
            Stack<string> stack = new Stack<string>(param.Reverse());
            
            foreach(var c in s)
            {
                if (c == '{')
                {
                    opened = true;
                    index = result.Length;
                }
                else if (opened && c == '}')
                {
                    opened = false;
                    var p = stack.Count > 0 ? stack.Pop() : optional;
                    var lenToRem = result.Length - index;
                    result.Remove(index, lenToRem);
                    result.Append(p);
                    continue;
                }
                else if (opened && !Char.IsDigit(c))
                {
                    opened = false;
                }
                result.Append(c);
            }
            return result.ToString();
        }

            string s = "my test string";
            char[] c = s.ToArray();
            bool CapitalNext = true;
            string o = null;
            foreach (char ch in c)
            {
                if (CapitalNext)
                    o += ch.ToString().ToUpper();
                else
                    o += ch.ToString();
                CapitalNext = false;
                if (char.IsWhiteSpace(ch))
                {
                    CapitalNext = true;
                }
            }
            return o;

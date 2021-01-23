        private List<string> RecPermute(string soFar, string rest, List<string> tmp = null)
        {
            if (tmp == null) tmp = new List<string>();
            if (rest == "")
            {
                //soFar.Dump();
                tmp.Add(soFar);
            }
            else
            {
                for (int i = 0; i < rest.Length; i++)
                {
                    string next = soFar + rest[i];
                    string remaining = rest.Substring(0, i) + rest.Substring(i + 1);
                    RecPermute(next, remaining, tmp);
                }
            }
            return tmp;
        }

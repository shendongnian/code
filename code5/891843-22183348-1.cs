    public void parse()
    {
        string s = @"`020             Some Description       `060       A Different Description        `100       And Yet Another       `";
        Int32 first;
        String second;
        if (s.Contains('`'))
        {
            foreach (string firstSecond in s.Split('`'))
            {
                System.Diagnostics.Debug.WriteLine(firstSecond);
                if (!string.IsNullOrEmpty(firstSecond))
                {
                    firstSecond.TrimStart();
                    Int32 firstSpace = firstSecond.IndexOf(' ');
                    if (firstSpace > 0)
                    {
                        System.Diagnostics.Debug.WriteLine("'" + firstSecond.Substring(0, firstSpace) + "'");
                        if (Int32.TryParse(firstSecond.Substring(0, firstSpace), out first))
                        {
                            System.Diagnostics.Debug.WriteLine("'" + firstSecond.Substring(firstSpace-1) + "'");
                            second = firstSecond.Substring(firstSpace).Trim();
                        }
                    }
                }
            }
        }
    }

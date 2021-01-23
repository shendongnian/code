        static void Main(string[] args)
        {
            string yourstring = @"In an out of the box way to reduce number of cigarette consumption per day, Vineet, a Delhi University student has started smoking longer cigarettes. Cigarettes have a bad influence on health";
            StringBuilder final = new StringBuilder();
            CultureInfo culture = CultureInfo.CurrentCulture;
            foreach (string split in yourstring.Split(' '))
            {
                if (culture.CompareInfo.IndexOf(split,"cigarette",CompareOptions.IgnoreCase)!=-1)
                {
                    final.Append(@"<span style='color: red;'>");
                    final.Append(split);
                    final.Append(@"</span>");
                }
                else
                {
                    final.Append(split);
                }
                final.Append(' ');
            }
        }

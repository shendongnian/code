        private long TestIndexOf(string haystack, char[] needles)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                int x = haystack.IndexOfAny(needles);
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
        private long TestRegex(string haystack, char[] needles)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            Regex regex = new Regex(string.Join("|", needles));
            for (int i = 0; i < 1000000; i++)
            {
                Match m = regex.Match(haystack);
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
        private long TestIndexOf(string haystack, char[] needles)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                int x = haystack.IndexOf(needles[0]);
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
        private long TestHashset(string haystack, char[] needles)
        {
            HashSet<char> specificChars = new HashSet<char>(needles.ToList());
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                bool notContainsSpecificChars = !haystack.Any(specificChars.Contains);
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

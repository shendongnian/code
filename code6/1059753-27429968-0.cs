    public static class Extensions
    {
        public static IEnumerable<string> MyReadLines(this FileStream f)
        {
            var sr = new StreamReader(f);
            
            var line = sr.ReadLine();
            while (line != null)
            {
                yield return line;
                line = sr.ReadLine();
            }
        }
    }

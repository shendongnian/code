        public static IEnumerable<int> ReadInts(string path)
        {
            var txt = File.ReadAllText(path);
            return Regex.Split(txt, @"\s+").Select(x => int.Parse(x));
        }

        public string TrimFromRightToFirstSpace(string s)
        {
            if (s == null || s.IndexOf(' ') == -1)
                return s;
            var split = s.Split(' ');
            return String.Join(" ", s.Take(split.Length-1).ToArray());
        }

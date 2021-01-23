        public string TrimFromLeftToFirstSpace(string s)
        {
            return s==null || s.IndexOf(' ')==-1
                ? s 
                : String.Join(" ", s.Split(' ').Skip(1).ToArray());
        }

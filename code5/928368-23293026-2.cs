        string str = "this this is is a a string";
        private int count(string key)
        {
            string[] ar = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, string> d = new Dictionary<int, string>();
            for (int i = 0; i < ar.Length; i++)
                d.Add(i, ar[i]);
           return d.Where(x => x.Value == key).ToList().Count;
        }

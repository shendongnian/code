    class MappingWithoutGenerics
    {
        public string Map(int x)
        {
            return x.ToString();
        }
        public int Map(string s)
        {
            return Convert.ToInt32(s);
        }
    }

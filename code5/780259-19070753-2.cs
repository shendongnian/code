    [Serializable]
    class X
    {
        private readonly Dictionary<string, Dictionary<string, string>> dic;
        public X()
        {
            dic = new Dictionary<string, Dictionary<string, string>>();
        }
        public void Add()
        {
            this.dic.Add("x", new Dictionary<string, string>() { { "a", "b" } });
        }
        //Property exposing private field 'dic'.
        public Dictionary<string, Dictionary<string, string>> Dictionary
        {
            get
            {
                return dic;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var x = new X();
            x.Add();
            string msg = new JavaScriptSerializer(new SimpleTypeResolver()).Serialize(x);
            var y = new JavaScriptSerializer(new SimpleTypeResolver()).Deserialize<X>(msg);
        }
    }

    public class Product
    {
        public class Version
        {
            public string vers = "";
            public override string ToString()
            {
                return vers;
            }
        }
        public string name = "";
        public List<Version> versions = new List<Version>();
        public override string ToString()
        {
            return name;
        }
    }

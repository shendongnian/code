    public class Product
    {
        public class Version
        {
            public double vers = 0;
            public override string ToString()
            {
                return vers.ToString();
            }
        }
        public string name = "";
        public List<Version> versions = new List<Version>();
        public override string ToString()
        {
            return name;
        }
    }

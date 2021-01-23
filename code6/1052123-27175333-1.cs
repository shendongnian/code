    HashSet<CustomObject> x = new HashSet<CustomObject>(new XE());
    public class CustomObjectEqualityComparer : IEqualityComparer<CustomObject>
    {
        public bool Equals(CustomObject x, CustomObject y)
        {
            return x.Var1 == y.Var1 && x.Var2 == y.Var2;
        }
        public int GetHashCode(string obj)
        {
            //
        }
    }
    public class CustomObject
    {
        public string Var1 { get; set; }
        public string Var2 { get; set; }
    }

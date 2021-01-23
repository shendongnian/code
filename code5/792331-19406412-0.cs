    public class LinqTest
    {
        public int id { get; set; }
        public string value { get; set; }
        public override bool Equals(object obj)
        {
            LinqTest obj2 = obj as LinqTest;
            if (obj2 == null) return false;
            return id == obj2.id;
        }
        public override int GetHashCode()
        {
            return id;
        }
    }

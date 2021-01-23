    public class Test : IEquatable<Test>
    {
        public string Test1 { get; set; }
        public string Test2 { get; set; }
        public string Test3 { get; set; }
        public bool Equals(Test other)
        {
            if (other == null) return false;
            return Test1.Equals(other.Test1)
                && Test2.Equals(other.Test2)
                && Test3.Equals(other.Test3);
        }
    }

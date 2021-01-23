    class Test : IEquatable<Test>
    {
        public string Name { get; set; }
        public int OtherProperty { get; set; }
        
        public bool Equals(Test other)
        {
            return other.Name == this.Name;
        }
    }

    public class S
    {
        private A ClassA { get; set; }
        public S()
        {
            ClassA = new A();
        }
        private class A
        {
            public int TestProperty { get; set; }
        }
        public int GetClassATestProperty
        {
            get
            {
                return this.ClassA.TestProperty;
            }
        }
    }

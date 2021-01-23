    [AttributeUsage(System.AttributeTargets.All, AllowMultiple = false)]
    public sealed class TestAttribute : Attribute
    {
        public TestAttribute(int num, string name)
        {
            Num = num;
            Name = name;
        }
        public int Num { get; private set; }
        public string Name { get; private set; }
    }

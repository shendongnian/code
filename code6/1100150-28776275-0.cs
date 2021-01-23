    public sealed class MyTestEnum
    {
        public int Num { get; private set; }
        public string Name { get; private set; }
    
        private MyTestEnum(int num, string name)
        {
            Num = num;
            Name = name;
        }
    
        public static readonly Foo = new MyTestEnum(1, "hi");
        public static readonly Bar = new MyTestEnum(2, "cool");
    }

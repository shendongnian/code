    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(1 == MyEnum.Value0);
            Console.WriteLine(2 == MyEnum.Value2);
        }
    }
    public class MyEnum
    {
        public static readonly MyEnum Value0 = 0;
        public static readonly MyEnum Value1 = 1;
        public static readonly MyEnum Value2 = 2;
        private MyEnum() { }
        private int _val;
        private MyEnum(int val)
        {
            _val = val;
        }
        public static implicit operator int(MyEnum val)
        {
            return val._val;
        }
        public static implicit operator MyEnum(int val)
        {
            return new MyEnum(val);
        }
    }

    public int i;
    public MyClass()
    {
    }
    public class MyCla : MyClass
    {
        public MyCla()
        {
        }
        int ij = 12;
        public new void Display()
        {
            MyClass m = new MyClass();
            m.i = 100; // accessible
            Console.WriteLine("Derived dis");
        }
    }

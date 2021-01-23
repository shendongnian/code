    public class MyCla : MyClass
    {
        public MyCla()
        {
            base.i=100;
        }
        int ij = 12;
        public new void Display()
        {
            MyClass m = new MyClass();
            base.i=100; // Accessible
            m.i = 100; // Not Accessible
            Console.WriteLine("Derived dis");
        }
    }

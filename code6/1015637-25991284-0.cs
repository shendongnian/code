    public class MyClass
    {
        protected int i;
        public MyClass()
        {
        }
        public virtual void Display()
        {
            Console.WriteLine("Base dis");
        }
    }
    public class MyCla : MyClass
    {
        public MyCla()
        {
        }
        int ij = 12;
        public new void Display()
        {
            Console.WriteLine(this.i);
        }
    }

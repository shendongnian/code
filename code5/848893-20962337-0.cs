    class Program
        {
            static void Main(string[] args)
            {
                //both 'i' properties exist
                Derived d = new Derived();
    
                Console.WriteLine(d.i);  // uses the 'i' for this type
                Console.WriteLine(((Base)d).i); // uses the 'i' for this type
                Console.ReadLine();
            }
        }
    
    class Base
    {
        int _i = 0;
        public  int i
        {
            get { return _i; }
    
        }
    
        public String sayIt()
        {
            //this class and this method doesn't realize the derived class has hid this.i
            return Convert.ToString(this.i);
        }
    }
    
    class Derived : Base
    {
        int _i = 1;
        public new int i
        {
            get { return _i; }
        }
    }

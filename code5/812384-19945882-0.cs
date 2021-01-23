    public class A
    {
        public static A operator + (A left, A right)
        {
            //Calculations
    		Console.WriteLine ("base A was called");
            return new A();
        }
    }
    
    public class B : A
    {
        public static B operator + (B left, B right)
        {
            //Calculations
            A res = right + (A)left;
            return new B();
        }
    }

    public class A
    {
        public int AValue { get; set; }
    }
    
    public class B
    {
        public int BValue { get; set; }
    
        public static explicit operator B(A instanceOfA)
        {
            return new B { BValue = instanceOfA.AValue };
        }
    }

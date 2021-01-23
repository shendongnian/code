    public class A
    {
        public int X;
    
        public A Clone()
        {
            return (A) MemberwiseClone();
        }
    }

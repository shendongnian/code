    public class AClass
    {
        private int x, y, z;
        public static readonly AClass Empty = new AClass();
        // So that you can't do a new AClass() outside of this class
        private AClass()
        {
        }
        public static AClass RetB(int x, AClass c)
        {
            AClass b;
            b = new AClass();
            b.x = x;
            if (c != null)
            {
                b.y = c.y;
                b.z = c.z;
            }
            return b;
        }
    }

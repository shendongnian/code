    public class C<ABC, DEF> : A<ABC, DEF>
    {
        public C()
        {
        }
        public override int GetObject(ABC abc, DEF def)
        {
            return 10;
        }
        public override int GetAnotherObject(B b)
        {
            return 15;
        }
    }

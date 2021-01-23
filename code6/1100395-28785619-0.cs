    public class C<ABC, DEF> : A<ABC, DEF>
    {
        public C()
        {
    
        }
        public override int GetObject(ABC abc, DEF def)
        {
            return 10;
        }
    
        // since B is a nested class of A, it has no scope outside of A
        // outside of the definition of A, it must always be referred to as A.B
        public override int GetAnotherObject(A.B b)
        {
            return 15;
        }
    }

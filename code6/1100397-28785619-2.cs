    public class C<ABC, DEF> : A<ABC, DEF> 
    {
        // C's implementation of A
        public override int GetAnotherObject(A<ABC,DEF>.B b)
        {
            return 15;
        }
        public class D : A<ABC,DEF>.B
        {
            // implementation of A.B
        }
    }

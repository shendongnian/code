    public class Foo
        {   
            public readonly int myInt;   
            public Foo()
            {
                myInt = 1;
            }
            public void doBad()
            {
                myInt = 1213; // Not allowed
            }
        }

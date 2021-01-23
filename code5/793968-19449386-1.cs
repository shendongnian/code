        interface IA 
        { 
            int xxx(); 
        }
        abstract class B 
        { 
            public abstract int yyy();
        }
        class C : B, IA
        {
            public int xxx()
            {
                return 1;
            }
            public int yyy()
            {
                return 1;
            }
        }

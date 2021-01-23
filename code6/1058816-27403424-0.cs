    namespace Whatever
    {
        partial class Partial
        {
            private int a = 1;
        }
        partial class Partial
        {
            public int A
            {
                get
                {
                    return this.a;
                }
            }
        }
    }

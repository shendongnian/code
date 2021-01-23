        class A
        {
            // no longer needed
            //public A()
            //{
            
            //}
            public A(SomeStuff stuff)
            {
                if (stuff != null)
                {
                    // init stuff
                }
            }
        }
        class B : A
        {
            public B() : this(null)
            {
            
            }
            public B(SomeStuff stuff) : base(stuff)
            {
                if (stuff != null)
                {
                    // init stuff more
                }
            }
        }

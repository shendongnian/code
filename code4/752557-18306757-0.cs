            A a = new A();
            B b = new B();
            C c = new C();
            if (b is A)
            {
                //True
            }
            if (c is B)
            {
                //True
            }
            if (c is A)
            {
                //True
            }
            if (a is B)
            {
                //False
            }
            A a1 = b as A;
            if (a1 != null)
            {
                //So a1 is b
            }

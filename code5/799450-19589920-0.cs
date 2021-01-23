    namespace OuterNamespace
    {
        public class DoStuff
        {
            public DoStuff()
            {
                //This DoStuff is different...
            }
        }
        namespace InnerNamespace
        {
            public class DoStuff
            {
                public DoStuff()
                {
                    //than this DoStuff.
                }
            }
        }
    }
    public class Test
    {
        public Test()
        {
            //This "DoStuff" class
            OuterNamespace.DoStuff outerStuff = new OuterNamespace.DoStuff();
            //Is different than this "DoStuff" class
            OuterNamespace.InnerNamespace.DoStuff innerStuff = new OuterNamespace.InnerNamespace.DoStuff();
        }
    }

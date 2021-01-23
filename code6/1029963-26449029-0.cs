    public class SomeClass
    {
        //Will be accessible by instance of this class 
        public int Field1 { get; set; }
        //Accessible within class methods only
        private int Field2 { get; set; }
        public void SomeMethod()
        {
            //You can use private property in any of method within class only
            Console.WriteLine(Field2);
        }
        //Accessible from derived class
        protected int Field3 { get; set; }
    }
    public class SomeDerived : SomeClass
    {
        public void SomeDerivedFunction()
        {
            //Accessing baseclass Property
            Console.WriteLine(Field3);
        }
    }
    public class SomeThirdPartyClass
    {
        private SomeClass sc;
        public SomeThirdPartyClass()
        {
            sc = new SomeClass();
            //Field one as public accessible in other classes by instance
            Console.WriteLine(sc.Field1);
        }
    }

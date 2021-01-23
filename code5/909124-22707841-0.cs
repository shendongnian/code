    class DerivedClass : BaseClass { }
    class Test
    {
        public Test(BaseClass c)
        {
        }
        public Test(DerivedClass c)
        {
        }
    }
    // Uses the most specific constructor, Test(DerivedClass):
    Activator.CreateInstance(typeof(Test), new DerivedClass());

    class SomeClass
    {
        private ISomeSharedContract dependency;
        public SomeClass(ISomeSharedContract dependency)
        {
            this.dependency = dependency;
        }
        private HereYourMethod(...)
        {
            // ...
            this.dependency.SomeMethod(); // Here you gain access to Assembly A object
            // ...
        }
    }

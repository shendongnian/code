    class Service
    {
        public void ServiceMethod1()
        {
            // Here you create type from Assembly B but inject object from Assembly A
            var obj = new SomeClass(new SomeSharedClass()); 
            
        }
    }
    class SomeSharedClass : ISomeSharedContract
    {
        // SomeMethod implementation
    }

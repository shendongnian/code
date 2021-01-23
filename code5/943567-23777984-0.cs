    class SomeClass
    {
        public void DoSomething<M,T>(M instance) where T : Base 
                                                 where M : GenericClass<T>
        {
           // Do something...
        }
    }

    class Class1 : MyBaseClass<Object>
    {
        protected override MyBaseClass<object> Get(object id)
        {
            return (MyBaseClass<object>) id;
        }
        protected override MyBaseClass<object> Get(string id)
        {
            return FindMyBaseClass(id)
        }
    }

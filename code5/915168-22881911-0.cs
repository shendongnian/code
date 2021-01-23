    class Parent
    {
        private System.Collections.IList _myChildList;
        public Parent(Type T)
        {
            Type listType = typeof(List<>);
            Type genericListType = listType.MakeGenericType(T);
            _myChildList = (System.Collections.IList)Activator.CreateInstance(genericListType);
        }
    }
    class Child : Parent
    {
        public Child()
            : base(typeof(SomeClass))
        {
        }
    }

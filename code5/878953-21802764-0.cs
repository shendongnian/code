    class ParentClass
    {
        private ChildClass _childClass = new ChildClass();
        public ChildClass ChildClass
        {
            get { return _childClass; }
        }
        public void EditChild()
        {
            _childClass.Name = "SOME VALUE";
        }
    }

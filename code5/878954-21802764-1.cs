    class ParentClass : INotifyPropertyChanged
    {
        private ChildClass _childClass = new ChildClass();
        public ChildClass ChildClass
        {
            get { return _childClass; }
            set { 
                if(_childClass != value) {
                    OnPropertyChanged("ChildClass");
                    // This one is necessary so that the ChildOfChildClass property/binding gets updated accordingly
                    OnPropertyChanged("ChildOfChildClass");
                }
            }
        }
        public ChildClass ChildOfChildClass
        {
            get { return (_childClass!=null)?_childClass.Child:null; }
        }
        public void EditChild()
        {
            _childClass.Name = "SOME VALUE";
        }
        // Implament PropertyChanged handling in Parent class too
        ...
    }

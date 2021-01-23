        public int? some_val { get; set; }
        public ChildObject _child;
        public ChildObject child
        {
            get {
               //if the chld hasnt been set already
                if (_child == null)
                {
                    //if the value of the integer has been set
                    if(some_val != null)
                    {
                        SomeMethod();
                    }
                }
                return _child;
            }
            set { _child = value;}
        }
    
        private void SomeMethod()
        {
            int new_val = this.some_val.Value + 5;
            this.child = new ChildObject {  some_val = new_val };
        }

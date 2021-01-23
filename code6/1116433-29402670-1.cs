    class ChildProperties
    {
        private Parent _ObjParent;
        // Exposing the Parent (if needed) and Child properties
        public string Name{ get { return this._ObjParent.ObjChild.Name; } }
        public intAge { get { return this._ObjParent.ObjChild.Age; } }
        public Parent(Parent parent) 
        {
            this._ObjParent = parent;
        }
    }

    class ChildProperties
    {
        private Parent _ObjParent;
        // Exposing the Parent (if needed) and Child properties
        pubic string Name{ get { return this._ObjParent.ObjChild.Name; } }
        pubic intAge { get { return this._ObjParent.ObjChild.Age; } }
        public Parent(Parent parent) 
        {
            this._ObjParent = parent;
        }
    }

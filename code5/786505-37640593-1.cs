     class Parent
     {
          private Parent _parent;
          public Parent()
          {
             _parent = this;
          }
         protected Parent GetParent()
         {
             return _parent;
         }
     }
    class Child : Parent
    {
        private Parent _parent;
        public Child()
        {
            _parent = base.GetParent();
        }
    }
          

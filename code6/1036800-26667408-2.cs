     class ParentClass
     {
         public ChildClass GetChild()
         {
             return new ChildClass(this);
         }
     }

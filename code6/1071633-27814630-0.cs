        class ParentClass
           {
              public int Normal()
              {
                return 1;
              }
           }
        // Derived class
           class ChildClass: ParentClass
           {
              public int someMethod()
              { 
                 return Normal();         
              }
           }

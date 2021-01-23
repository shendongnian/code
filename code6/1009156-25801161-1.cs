    class Base
    {
         private IDep dep;
         [InjectionMethod]
         public void Initialize(IDep dep)
         {
             this.dep = dep;
         }
    }

     class ParentClass
     {
         public ParentClass() { }
         public class ChildClass
         {
             public ParentClass Parent { get; set; }
             public ChildClass(ParentClass par)
             {
                 this.Parent = par;
             }
         }
    
         public ChildClass GetChild()
         {
             return new ChildClass(this);
         }
     }

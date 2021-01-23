    public class A
    {
      // store the parent type
      private Type mParentClass; 
      // provide parent type during construction of A
      public A(Type parentClass)
      {
         mParentClass = parentClass;
      }   
    
      // note that method cannot be static anymore, since every instance of A might 
      // have a different parent
      public void SomeAction()
      {
         // access field where parent type is stored.
         Debug.Write("I was declared in class: {0} and my name is:",mParentClass.Name);
      }
    }

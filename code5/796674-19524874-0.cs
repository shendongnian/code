      namespace A
      {
    
         public abstract class BaseClass
         {
             protected virtual string GetData()
             {
                 throw new NotImplementedException();
             }
         }
      }
    
      namespace B  //includes a reference to A
      {
      	 public abstract class BaseClass
         {
         }
      	
      	
         abstract class DerivedClassA : BaseClass
         {
    
         }
    
    
         internal class DerivedClassB: DerivedClassA
         {
              public void write()
              {
                 base.GetData(); // results in error.
    
                 // The name 'GetData' does not exist in the current context
                 // and DerivedClassA does not contain a definition for 'GetData'
              }
         }
      }

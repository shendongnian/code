          namespace ConsoleApplication1
          {
               class Program
               {
                  static void Main(string[] args)
                  {}
                }
              
              public abstract class MyAbsClass
              {
                  public string DoSomething()
                  {
                     return DoSomethingInternal();
           
                  }
               internal abstract string DoSomethingInternal();
               public abstract string DoSomethingExternal();
       
              }
              public  class MyClass:MyAbsClass
              {
                     internal override string DoSomethingInternal(){}                   
                     public override string DoSomethingExternal(){}
                    
              }
           }

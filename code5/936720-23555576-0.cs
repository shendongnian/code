    public abstract class Base
    {
         public virtual MySubClass subClass {get;set;}
         public abstract class MySubClass
         {
             public string Hello() {return "hello";}
         }
         public abstract MySubClass CreateSubClass();
    }

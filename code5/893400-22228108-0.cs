    public class MyBaseClass
    {
         public int SomeProperty {get; set;}
         public virtual int AnotherProperty {get; set;}
    
         public MyBaseClass(int sp) {
             SomeProperty = sp;
         }
    }
    
    public class MyDerivedClass : MyBaseClass
    {
         public MyDerivedClass(int sp, int ap):base(sp)
         {
             AnotherProperty = ap;
         }
    }

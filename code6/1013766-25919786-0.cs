     abstract class SomeBase
     {
          private SomeObject _obj { get; set; } 
          public SomeObject obj 
          {
               get 
               {    // check _obj is inited:
                    if (_obj == null) throw new <exception of your choice> ;
                    return _obj;
               } 
          }
          protected SomeBase()
          {
               obj = null;
          }
          protected void Init()
          {
               obj = x;
          }
          //Other methods and fields...
     }
     public class SomeDerived : SomeBase
     {
          public SomeDerived() : base()
          {
               Init(new SomeObject(this));
          }
     }

    public class SomeBase {
        public SomeBase(){}
    
        public SomeBase(OtherThings otherThings):this(){}
    }
    public class SomeClass : SomeBase
    {
          public SomeClass(): base()
          {
              // Init a lot of lists and stuff
          }
    
          public SomeClass(OtherThings otherThings): base(otherThings)
                 // :this()  <----- This is not legal syntax
          {
              // Do stuff with otherThings
          }
    }

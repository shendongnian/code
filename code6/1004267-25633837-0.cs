    public class SomeClass : SomeBase
    {
          public SomeClass()
          {
              // Init a lot of lists and stuff
              CommonStuff();
          }
    
          public SomeClass(OtherThings otherThings): base(otherThings)
          {
              CommonStuff();
    
              // Do stuff with otherThings
          }
    
          private void CommonStuff()
          {
             // init common between both
          }
    }

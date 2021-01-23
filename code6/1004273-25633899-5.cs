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

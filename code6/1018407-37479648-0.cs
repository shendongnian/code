        void method1(){
          foreach(var x in y)
          {
              Validate(x);
              ...
              //Your other logic
              ...
        
            EndOfLoop:
              ;
          }
        }
        ..
        ..
        void Validate(T x)
        {
        #if IL
          br EndOfLoop
        #endif
        }
    //End Of Code

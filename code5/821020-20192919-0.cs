    namespace Test
    {
      delegate int MyDel(); // semicolon required after delegate type declaration
    
      abstract class Class
      {
        int Field1;      // semicolon required after field
        int Field2 = -1; // semicolon required after field with initializer
    
        int Property1
        {
          get
          {
            return 42; // semicolon required after statement
          }  // semicolon disallowed after end of accessor body
          set
          {
          }  // semicolon disallowed after end of accessor body
        } // semicolon disallowed after end of property block
    
        int Method1()
        {
          Some.Statement.Here(); // semicolon required after statement
          Some.Statement.Here(); // semicolon required after statement
          ;                      // extra semicolon means empty statement here, OK
          return 10;             // semicolon required after statement
        }                        // semicolon disallowed after end of method body
    
        protected abstract int Method2();  // semicolon required when method block or accessor block is absent
      }; // semicolon optional after declaration of class, struct, interface, enum
    }; // semicolon optional after namespace block

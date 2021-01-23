    class A {
      int x, y;
    
      // Hidden constructor 
      protected A() {
        x = 10;
        y = 4;
      }
    
      // Factory method to create A class instances
      public static A Create() {
        ...
        A result = new A();
        ...
        return result;  
      }
    }

      public class a {
        public a(int value) {...}
      }
    
      public class b: a {
        // b doesn't inherit any "a" constructors, 
        // (you can't call "b(1)" unless you provide "public b(int value)" constructor)        
        // but can call base class constructor if required
        public b(): base(0) {...}
      } 

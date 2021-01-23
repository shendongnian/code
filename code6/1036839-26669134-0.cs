      public class MyClass {
        ...
        // True if instance is not null, false otherwise
        public implicit operator Boolean(MyClass value) {
          return !Object.ReferenceEquals(null, value);  
        }   
      }
    
    
    ....
    
      MyClass myobject = new MyClass();
      ...
      if (myobject) { // <- Same as in JavaScript
        ...
      }

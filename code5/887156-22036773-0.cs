      public class MyClass {
        ...
        // static event doesn't need any instance and so 
        // could be called within constructor
        public static event EventHandler MyClassCreated;
       
        public MyClass() {
          ...
          if (!Object.ReferenceEquals(null, MyClassCreated))
            MyClassCreated(this, EventArgs.Empty);
        } 
      }

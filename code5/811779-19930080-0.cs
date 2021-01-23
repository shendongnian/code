     class MyClass {
           public MyClass(string value) {
               if (value == null)
                   throw new ArgumentNullException("value");
               ... 
          }
     }

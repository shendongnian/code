    foreach(var asm in loadedAssemblies)
    {
       var classes = asm.GetTypes(); // you can use GetTypes to get all classes in that assembly
       foreach(var c in classes)
       {
          // you can get all methods which is defined in this class with GetMethods
          var methods = c.GetMethods();
          
          // or you can get all properties defined in this class
          var props = c.GetProperties();
       }
    }  

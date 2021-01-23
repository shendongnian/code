    foreach (var file in Directory.GetFiles(path, "*.dll"))
    {
        var a = Assembly.LoadFrom(file);
        foreach (var t in a.GetTypes())
        {   
              //-- My code
              // Searches for the public method with the specified name.
              MethodInfo mInfo = t.GetMethod("YourMethodName");
              if(mInfo != null)
              {
                 // method found
              }
              // Note :- The search for name is case-sensitive. The search includes public static and public instance methods.
              // -- End
        }
    }

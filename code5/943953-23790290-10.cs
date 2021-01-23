      // utility code
      public static class ExtensionMethods
      {
          public static string MyExtensionMethod(this string myString)
          {
              return "ranextension on string '" + myString + "'";
          }
  
          public static object InvokeExtensionMethod(this object instance, string methodName, params object[] arguments)
          {
              if (instance == null) throw new ArgumentNullException("instance");
  
              MethodInfo mi = ExtensionMethodsHelper.GetExtensionMethodOrNull(instance.GetType(), methodName);
              if (mi == null)
              {
                  string message = string.Format("Unable to find '{0}' extension method in '{1}' class.", methodName, instance);
                  throw new InvalidOperationException(message);
              }
    
              return mi.Invoke(null, new[] { instance }.Concat(arguments).ToArray());
          }
      }
    
      // example usage    
      Console.WriteLine("hey".InvokeExtensionMethod("MyExtensionMethod"));

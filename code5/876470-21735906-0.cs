    ValidatorOptions.ResourceProviderType = typeof(MyResources);
...
    public class MyResources {
       public static string notempty_error {
          get { 
              return "Field should not be empty.";
          }
       }
    }

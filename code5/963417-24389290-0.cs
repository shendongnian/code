    public class Errors
    {
         public static class IntegerErrors {
              public const string ERR123 = 123;
          }
         public static class StringErrors {
             public const string ERR123 = "Error 123, something went wrong.";
         }
    }
    ...
    int i_value = Errors.IntegerErrors.ERR123;
    string s_value = Errors.StringErrors.ERR123;

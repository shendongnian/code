    string[] values = { null, String.Empty, "True", "False", 
                          "true", "false", "    true    ", "0", 
                          "1", "-1", "string" };
      foreach (var value in values) {
         try {
            bool flag = Boolean.Parse(value);
            Console.WriteLine("'{0}' --> {1}", value, flag);
         }
         catch (ArgumentException) {
            Console.WriteLine("Cannot parse a null string.");
         }   
         catch (FormatException) {
            Console.WriteLine("Cannot parse '{0}'.", value);
         }         
      }            
    // The example displays the following output: 
    //       Cannot parse a null string. 
    //       Cannot parse ''. 
    //       'True' --> True 
    //       'False' --> False 
    //       'true' --> True 
    //       'false' --> False 
    //       '    true    ' --> True 
    //       Cannot parse '0'. 
    //       Cannot parse '1'. 
    //       Cannot parse '-1'. 
    //       Cannot parse 'string'.

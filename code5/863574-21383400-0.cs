     public static ActionTypeExtension {
       // Extension method: extends ActionType ("this" before ActionType)
       // returns string
       public static String ToReport(this ActionType value) {
         if (value == ActionType.Button)
           return "button";
         else
           return "link";
       } 
     }
    
    ....
    
      ActionType action = ActionType.Button;
      String result = action.ToReport(); // <- "button"

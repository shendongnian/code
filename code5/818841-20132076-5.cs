     public static class AutoMapperSafeMemberAccessExtension
     {
         public static void IfSafeAgainst<T,TException>(this IMemberConfigurationExpression<T> options, Func<T,object> get)
             where TException : Exception
         {
             return options.Condition(source => {
                 try { var value = get(source); return true; }
                 catch(TException) { return false; }
             });
         }
     } 

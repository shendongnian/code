     public static class AutoMapperSafeMemberAccessExtension
     {
         public static void IfSafeAgainst<T,TException>(this IMemberConfigurationExpression<T> options, Func<T,object> get)
             where TException : Exception
         {
             return options.Condition(source => {
                 try { string value = source.PositionFolder; return true; }
                 catch(StrongTypingException) { return false; }
             });
         }
     } 

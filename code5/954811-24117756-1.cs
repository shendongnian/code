     public static class ValueHelper<T> {
         public static Func<T,object> ValueFunction;
  
         public static object GetValue(T item) {
            var function = ValueFunction;
            return function == null ? null : function(item);
         }
            
         }
     }

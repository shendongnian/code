     private Action<object> GetSetter(PropertyInfo info)
     {
         // 'this' is the owner of the property
         var method = info.GetSetMethod();
         var parameterType = method.GetParameters().First().ParameterType;
         
         // have the parameter itself be of type "object"
         var parameter = Expression.Parameter(typeof(object), "value");
         // but convert to the correct type before calling the setter
         var methodCall = Expression.Call(Expression.Constant(this), method, 
                            Expression.Convert(parameter,parameterType));
        
         return Expression.Lambda<Action<object>>(methodCall, parameter).Compile();
            
      }

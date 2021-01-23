    public class MethodRunner {
         public T RunMethod<T>(Expression<Func<T>> method) {
              var body = method.Body as MethodCallExpression;
              if (body == null)
                  throw new NotSupportedException();
               var attributes = body.Method.GetCustomAttributes(false);
               // Do something with Attributes
               return expression.Compile().Invoke();
         }
    }

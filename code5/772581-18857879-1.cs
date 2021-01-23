    public class FooClient<T>
    {
        public void SendMessage(Expression<Action<T>> expr)
        {
            var iMemberName = ((MethodCallExpression)expr.Body).Method.Name;
    
            Console.WriteLine(iMemberName);
        }
    }

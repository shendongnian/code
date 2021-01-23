    public static class AnonymousAction
    {
        public static Delegate WrapDelegate(Action action, Type targetType)
        {
            var invoke = targetType.GetMethod ("Invoke");
            if (invoke == null)
                throw new ArgumentException ("ofType must be delegate");
            var parameters = invoke.GetParameters ();
            var expressionParams = new ParameterExpression[parameters.Length];
            for (int i=0; i<parameters.Length; ++i)
            {
                expressionParams [i] = Expression.Parameter (parameters [i].ParameterType);
            }
            var call = Expression.Call (
                Expression.Constant(action),
                typeof(Action).GetMethod ("Invoke")
                );
            return Expression.Lambda (targetType, call, expressionParams).Compile ();
        }
    }
    public class MyReceiver
    {
        public event Action<MyReceiver, int> OnAction;
        public void Do()
        {
            OnAction (this, 22);
        }
    }
    public class Test
    {
        public void Run()
        {
            Action onAction = () => {
                Console.WriteLine ("Did something");
            };
            var receiver = new MyReceiver ();
            var evt = receiver.GetType ().GetEvent ("OnAction");
            evt.AddEventHandler (receiver, AnonymousAction.WrapDelegate (onAction, evt.EventHandlerType));
            receiver.Do ();
        }
    }
    static void Main()
    {
        var t = new Test ();
        t.Run ();
    }

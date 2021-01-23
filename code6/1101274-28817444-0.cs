    //TODO come up with a better name
    public class Foo
    {
        private static void InvokeAll(Action[] actions)
        {
            foreach (var action in actions)
                action();
        }
        public static Expression Block(IEnumerable<Expression> expressions)
        {
            var invokeMethod = typeof(Foo).GetMethod("InvokeAll",
                BindingFlags.Static | BindingFlags.NonPublic);
            var actions = expressions.Select(e => Expression.Lambda<Action>(e))
                .ToArray();
            var arrayOfActions = Expression.NewArrayInit(typeof(Action), actions);
            return Expression.Call(invokeMethod, arrayOfActions);
        }
    }

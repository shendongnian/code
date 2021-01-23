        static void Main()
        {
            SeveralCalls(() => CallWithParams("test", null),
                         () => CallWithParams("AnotherTest", null));
        }
        public static void SeveralCalls(params Expression<Action>[] expressions)
        {
            foreach (var expression in expressions)
            {
                var modifiedExpression = ModifyExpression(expression);
                var action = modifiedExpression.Compile();
                action();
            }
        }
        private static Expression<Action> ModifyExpression(Expression<Action> expression)
        {
            var lambda = expression as LambdaExpression;
            if (lambda == null)
                return expression;
            var call = lambda.Body as MethodCallExpression;
            if (call == null)
                return expression;
            var method = typeof(Program).GetMethod("CallWithParams");
            if (call.Method != method)
                return expression;
            if (call.Arguments.Count < 1 || call.Arguments.Count > 2)
                return expression;
            var firstArgument = call.Arguments[0];
            var secondArgument = (call.Arguments.Count == 2 ? call.Arguments[1] : null);
            var secondArgumentAsConstant = secondArgument as ConstantExpression;
            if (secondArgumentAsConstant == null || secondArgumentAsConstant.Value == null)
                secondArgument = Expression.Constant("overridden value");
            var modifiedCall = Expression.Call(method, firstArgument, secondArgument);
            var modifiedLambda = Expression.Lambda<Action>(modifiedCall);
            return modifiedLambda;
        }
        public static void CallWithParams(string someValue, string otherValue = null)
        {
            Console.WriteLine("SomeValue: " + someValue);
            Console.WriteLine("OtherValue: " + otherValue);
        }

    public class Test2
    {
        public static void Main2()
        {
            // as expression tree
            var parameter1 = Expression.Parameter(typeof(int), "p1");
            var parameter2 = Expression.Parameter(typeof(int), "p2");
            var instance = new SampleClass();   // I'm sure I need this, but how to inject it into Expression.Call?
            var methodInfo = typeof(SampleClass).GetMethod("SampleMethod",
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var lambdaExpression = Expression.Lambda(
            Expression.Call(Expression.Constant(instance), methodInfo, new[] { parameter1, parameter2 }),
            parameter1, parameter2);
            // testing 
            var compiledExpr2 = (Action<int, int>)lambdaExpression.Compile();
            compiledExpr2(2, 2);
            compiledExpr2(4, 2);
        }
        public class SampleClass
        {
            public void SampleMethod(int x, int y)
            {
                Console.WriteLine(this);
            }
        }
    }

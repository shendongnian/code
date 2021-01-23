    public class Test
    {
        public static void TestMain()
        {
            // defined inline
            var expr = (Expression<Func<int, bool>>)(x => SumLargerThan5(x, 3));
            // testing 
            var compiledExpr1 = expr.Compile();
            bool b1 = compiledExpr1(2);
            bool b2 = compiledExpr1(4);
            // as expression tree
            var parameterExpr = Expression.Parameter(typeof(int));
            var methodInfo = typeof(Test).GetMethod("SumLargerThan5", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var lambdaExpression = Expression.Lambda(
                Expression.Call(methodInfo, parameterExpr, Expression.Constant(3)), 
                parameterExpr);
            // testing 
            var compiledExpr2 = (Func<int, bool>)lambdaExpression.Compile();
            bool b3 = compiledExpr2(2);
            bool b4 = compiledExpr2(4);
        }
        static bool SumLargerThan5(int x, int y)
        {
            return (x + y) > 5;
        }
    }

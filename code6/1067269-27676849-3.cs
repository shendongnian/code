    public class Helper
    {
        public bool SumLargerThan5(int x, int y)
        {
            return (x + y) > 5;
        }
    }
    public class Test
    {
        public static void TestMain()
        {
            // object with the instance method
            var helperObj = new Helper();
            
            // as expression tree
            var parameterExpr = Expression.Parameter(typeof(int));
            var methodInfo = typeof(Helper).GetMethod("SumLargerThan5", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var lambdaExpression = Expression.Lambda(
                Expression.Call(Expression.Constant(helperObj),
                    methodInfo, 
                    parameterExpr, 
                    Expression.Constant(3)), 
                parameterExpr);
            // testing 
            var compiledExpr2 = (Func<int, bool>)lambdaExpression.Compile();
            bool b3 = compiledExpr2(2);
            bool b4 = compiledExpr2(4);
        }
    }

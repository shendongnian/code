    public class Runner
    {
        public void Run()
        {
            var classToPass = new MyClass();
            classToPass.MyInt = 42;
            FuncExecutor.ExecuteAction(x => x.ProcessObject(classToPass));
        }
    }
    public class FuncExecutor
    {
        public static void ExecuteAction(Expression<Func<ObjectProcessor, int>> expression)
        {
            var lambdaExpression = (LambdaExpression)expression;
            var methodCallExpression = (MethodCallExpression)lambdaExpression.Body;
            var memberExpression = (MemberExpression)methodCallExpression.Arguments[0];
            var constantExpression = (ConstantExpression)memberExpression.Expression;
            var fieldInfo = (FieldInfo)memberExpression.Member;
            var myClassReference = (MyClass) fieldInfo.GetValue(constantExpression.Value);
            Console.WriteLine(myClassReference.MyInt); // prints "42"
        }
    }

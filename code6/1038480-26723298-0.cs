    public class MyClass
    {
        public int Value { get; set; }
    }
    
    static void Main(string[] args)
    {
        var obj1 = new MyClass { Value = 1 };
        var obj2 = new MyClass { Value = 2 };
    
        Expression<Func<int>> expr = () => obj1.Value + obj2.Value;
    
        BinaryExpression binaryExpr = (BinaryExpression)expr.Body;
        MemberExpression memberExpr = (MemberExpression)binaryExpr.Left;
        MemberExpression fieldExpr = (MemberExpression)memberExpr.Expression;
        ConstantExpression constantExpr = (ConstantExpression)fieldExpr.Expression;
                
        dynamic value = constantExpr.Value;
        MyClass some = value.obj1;
    }

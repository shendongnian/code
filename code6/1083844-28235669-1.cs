    static void Main(string[] args)
    {
        var memberInfo1 = GetMemberFromExpression(() => Method1(10, 20));
        var memberInfo2 = GetMemberFromExpression(() => Method2());
        var memberInfo3 = GetMemberFromExpression(() => Method3("string", 15, DateTime.Now));
        Console.WriteLine(memberInfo1.Name);
        Console.WriteLine(memberInfo2.Name);
        Console.WriteLine(memberInfo3.Name);
        Console.Read();
    }
    
    public static MemberInfo GetMemberFromExpression(Expression<Action> expression)
    {
        return ((MethodCallExpression)expression.Body).Method;
    }
    
    public static object Method1(int p1, int p2)
    {
        return p1 + p2;
    }
    
    public static void Method2()
    {
        // No return
    }
    
    public static double Method3(string p1, int p2, DateTime p3)
    {
        return 10d;
    }

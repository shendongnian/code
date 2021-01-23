    [Expandable]
    public static int LocalCountMyInnerClassPlus(MyClass x, int num)
    {
        // Not necessary to implement, unless you want to use it C#-side
        throw new NotImplementedException();
    }
    public static Expression<Func<MyClass, int, int>> LocalCountMyInnerClassPlusExpression()
    {
        return (x, num) => x.MyInnerClass.Count() + num;
    }

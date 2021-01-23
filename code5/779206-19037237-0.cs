    public delegate int AddOne(int input);
    
    public int Test(AddOne f)
    {
       return f(1);
    }
    void Main()
    {
        var input = Expression.Parameter(typeof(int));
        var add = Expression.Add(input,Expression.Constant(1));
        var lambda = Expression.Lambda(typeof(AddOne),add,input);
        var compiled = (AddOne)lambda.Compile();
        Console.WriteLine(Test(compiled)); // 2
    }

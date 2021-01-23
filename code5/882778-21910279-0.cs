    public static void takeAnything(Expression<Action> inputFunc)
    {
        var currentMethod = ((MethodCallExpression)action.Body);
        Console.WriteLine(inputFunc.Method.Name);
    }
    
    public static void test(MyOwnObject input){
        // Do stuff with input object
    }
    
    public static void startSystem(){
        MyOwnObject  yourObject = new MyOwnObject();
        takeAnything(() => test(yourObject));
    }

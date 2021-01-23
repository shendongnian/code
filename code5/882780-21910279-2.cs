    public static void takeAnything(Expression<Action> inputFunc)
    {
        var currentMethod = ((MethodCallExpression)inputFunc.Body);
        Console.WriteLine(currentMethod.Method.Name);
    }
    
    public static void test(MyOwnObject input){
        // Do stuff with input object
    }
    
    public static void startSystem(){
        MyOwnObject  yourObject = new MyOwnObject();
        takeAnything(() => test(yourObject));
    }

    public static void MakeQuack(object duck)
    {
        MethodInfo quackMethod = duck.GetMethod("Quack", Types.EmptyTypes);
        quackMethod.Invoke(duck, new object[] { });
    }

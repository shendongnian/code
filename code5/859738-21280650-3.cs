    public static void MakeQuack(object duck)
    {
        MethodInfo quackMethod = duck.GetType().GetMethod("Quack", Type.EmptyTypes);
        quackMethod.Invoke(duck, new object[] { });
    }

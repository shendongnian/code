    private delegate string delMethod();
    private static delMethod pntr_Method = new delMethod(OneDelegateMethod);
    public static string ExposedMethod()
    {
        return pntr_Method();
    }
    public static string OneDelegateMethod()
    {
        return "This is a string";
    }

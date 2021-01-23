    static void Main(string[] args)
    {
        var method = typeof(Program).GetMethod("Serialize");
        object myCollection = "12345".ToCharArray();
        //Get the element type for the array. In this case it is typeof(char)
        Delegate test = CreateOpenDelegate(method, null, myCollection.GetType().GetElementType());
        test.DynamicInvoke(myCollection);
        myCollection = new List<int> { 1, 2, 3, 4, 5 };
        //Get the generic argument for the collection type. In this case it is typeof(int)
        test = CreateOpenDelegate(method, null, myCollection.GetType().GetGenericArguments()[0]);
        test.DynamicInvoke(myCollection);
    }
    public static void Serialize<TElement>(IList<TElement> value)
    {
    }

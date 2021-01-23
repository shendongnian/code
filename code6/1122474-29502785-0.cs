    public static async Task MethodOneAsync()
    {
        DoSomeWork1();
        await MethodTwoAsync();
        DoOtherWork1();
    }
    public static async Task MethodTwoAsync()
    {
        DoSomeWork2();
        await MethodThreeAsync();
        DoOtherWork2();
    }
    public static async Task MethodThreeAsync()
    {
        DoSomeWork3();
        await DoDBWorkAsync();
        DoOtheWork3();
    }

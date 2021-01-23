    public static async Task MethodOneAsync()
    {
        DoSomeWorkOne();
        await MethodTwoAsync();
        DoMoreWorkOne();
    }
    public static async Task MethodTwoAsync()
    {
        DoSomeWorkTwo();
        await MethodThreeAsync();
        DoMoreWorkTwo();
    }
    public static async Task MethodThreeAsync()
    {
        DoSomeWorkThree();
        await Task.Delay(1000);
        DoMoreWorkThree();
    }

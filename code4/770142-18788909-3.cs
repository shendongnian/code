    public async Task HelloTest()
    {
        var data = await Task.WhenAll(Say(), Say());
    }
    private static async Task<int> Say()
    {
        await Task.Delay(100);
        return MyRandom.Next();
    }

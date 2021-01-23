    public async Task<int> SomeOtherMethodAsync()
    {
        int[] results = await Task.WhenAll(LongRunningThirdMethod(), LongRunningForthMethod());
        return results.Sum();
    }

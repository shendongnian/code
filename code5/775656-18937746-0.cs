    static async Task DoMasterOperationAsync()
    {
      var result = await StartSomething();
      await Task.WhenAll(DoComplexOperationAsync(), result.NextT1Async());
    }
    static async Task DoComplexOperationAsync()
    {
      var result1 = await T1Async();
      await Task.WhenAll(result1.NextT1Async(), result1.NextT2Async(), result1.NextT3Async());
    }
    await Task.WhenAll(DoMasterOperationAsync(), t2, t3, ...);

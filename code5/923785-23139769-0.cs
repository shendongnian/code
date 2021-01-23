    public async Task<MyResult> GetResult()
    {
      MyResult result = new MyResult();
      var tasks = Methods.Select(method => ProcessAsync(method)).ToArray();
      string[] json = await Task.WhenAll(tasks);
      result.Prop1 = PopulateProp1(json[0]);
      ...
      return result;
    }

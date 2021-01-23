    public async Task GetStuff()
    {
      var data = Enumerable.Range(1,100);
      Parallel.ForEach(data, async i =>
    {
        await Task.Delay(1000*i);
    	Console.WriteLine(i);
    });

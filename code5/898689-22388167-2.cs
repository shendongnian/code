    static async Task LoadAsync(int i)
    {
      var tasks = Enumerable.Range(0, i).Select(y => CallWcfAsync(y));
      List1.AddRange(await Task.WhenAll(tasks));
    }

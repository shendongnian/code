    public static async void startInitialDownload(string value) {
      IEnumerable<string> names = await Helper.getNames(value, 0);
      List<string> nameList = names.ToList();
      for (int i = 0; i < nameList.Count; i += 50) {
        string[] results = nameList.Skip(i).Take(50).ToArray();
        Task current = Task.Factory.StartNew(() => getCurrentData(results));
        await current.ConfigureAwait(false);
      }
    }

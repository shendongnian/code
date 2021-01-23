    public static async void startInitialDownload(string value) {
      IEnumerable<string> names = await Helper.getNames(value, 0);
      List<string> buffer = new List<string>();
      foreach (string s in names) {
        buffer.Add(s);
        if (buffer.Count == 50) {
          Task current = Task.Factory.StartNew(() => getCurrentData(buffer.ToArray()));
          await current.ConfigureAwait(false);
          buffer = new List<string>();
        }
      }
      if (buffer.Count > 0) {
        Task current = Task.Factory.StartNew(() => getCurrentData(buffer.ToArray()));
        await current.ConfigureAwait(false);
      }
    }

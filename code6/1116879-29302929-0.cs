    using (var client = new HttpClient())
    using (var reader = new StreamReader("List.txt"))
    {
      var line = await reader.ReadLineAsync();
      while (line != null)
      {
        var urlAddress = ("http://remote-server.com/variable=" + line);
        var result = await client.GetStringAsync(urlAddress);
        listBox1.Items.Add(result == "" ? "0" : result);
        line = await reader.ReadLineAsync();
      }
    }

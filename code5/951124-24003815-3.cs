    private const int PORT25 = 25; // I hate magic numbers
    foreach (var item in list) {
      var hostInfo = Dns.Resolve(item);
      Console.WriteLine(hostInfo);
      foreach (var address in hostInfo.AddressList) {
        var tc = new TelnetConnection(address, PORT25);
        Console.WriteLine("{0} TelnetConnection Connected: {1}", address, tc.IsConnected);
      }
    }

    static void Main(string[] args) {
      Store storeUSA = new Store {
        Country = "USA",
        Name = "Amazon.com",
        Salaries = new Dictionary<string, double>{
          {"Jones", 100000},
          {"Deborah",200000}
        }
      };
      Store storeBR = new Store {
        Country = "Brazil",
        Name = "Amazon.com",
        Salaries = new Dictionary<string, double>{
          {"Ricardo", 500000},
          {"Math", 800000}
        }
      };
      TcpClient tcpClient = new TcpClient("192.168.1.63", 6666);
      Console.WriteLine("Connected to Server");
      using (NetworkStream clientSockStream = tcpClient.GetStream()) {
        using (StreamWriter sw = new StreamWriter(clientSockStream)) {
          string output = JsonConvert.SerializeObject(storeUSA, Formatting.None);
          sw.WriteLine(output);
          sw.Flush();
          System.Threading.Thread.Sleep(2000);
          output = JsonConvert.SerializeObject(storeBR, Formatting.None);
          sw.WriteLine(output);
          sw.Flush();
          Console.WriteLine("Closing");
        }
      }
      Console.WriteLine("Done");
      Console.ReadLine();
    }
    

    public static void UpdateClient(UserConnection client) {
      string data;
      using (StreamReader reader = new StreamReader(client.TCPClient.GetStream(), Encoding.UTF8)) {
        data = reader.ReadToEnd();
      }
      Console.WriteLine("Data is: " + data);
      Console.WriteLine("Size is: " + data.Length);
      Server.Network.ReceiveData.SelectPacket(client.Index, data);
    }

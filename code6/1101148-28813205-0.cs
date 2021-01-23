    using (var client = new SshClient("127.0.0.1", 22, "root", "")) {
        client.Connect();
        if (client.IsConnected) {
            SshCommand x = client.RunCommand("cd ~");
        } else {
            Console.WriteLine("Not connected");
        }
        client.Disconnect();
    }

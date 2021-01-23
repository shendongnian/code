            StringBuilder response = new StringBuilder();
            
            SshClient client = new SshClient("host", "user", "pass");
            client.Connect();
            var cmd = client.RunCommand("ls -la");
            cmd.Execute();
            response.Append(cmd.Result);
            client.Disconnect();

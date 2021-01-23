      using (var client = new SshClient (conn) )
            {
                client.Connect();
                ShellStream shells = client.CreateShellStream("test", 80, 24, 800, 600, 1024);
                shells.WriteLine("echo Type letter A please");
                shells.WriteLine("read letter");
                shells.WriteLine("A");
                shells.WriteLine("echo $letter");
                string output = shells.Read();
            }

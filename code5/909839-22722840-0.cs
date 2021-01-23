        public string SSHConnect() {
            var PasswordConnection = new PasswordAuthenticationMethod("username", "password");
            var KeyboardInteractive = new KeyboardInteractiveAuthenticationMethod("username");
            string myData = null;
            var connectionInfo = new ConnectionInfo("10.56.1.2", 22, "username", PasswordConnection, KeyboardInteractive);
            
            using (SshClient ssh = new SshClient(connectionInfo)){
                ssh.Connect();
                var command = ssh.RunCommand(cmdInput);
                myData = command.Result;
                ssh.Disconnect();
            }
            
            return myData;
        }

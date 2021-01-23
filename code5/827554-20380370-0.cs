    private void writeMe()
    {
        using (StreamWriter sw = new StreamWriter(filename)
        {
            string result = eSshCom(command);
            sw.WriteLine(result);
        } 
    } 
    private string eSshCom(string getCommand)
                {
                this.res = "";
    
                var connectionInfo = new KeyboardInteractiveConnectionInfo(ipaddress, 22, username);
    
                connectionInfo.AuthenticationPrompt += delegate(object asender, AuthenticationPromptEventArgs xe)
                {
                    foreach (var prompt in xe.Prompts)
                        {
                        if (prompt.Request.Equals("Password: ", StringComparison.InvariantCultureIgnoreCase))
                            {
                            prompt.Response = password;
                            }
                        }
                };
    
                using (var ssh = new SshClient(connectionInfo))
                    {
                        ssh.Connect();
                        var cmd = ssh.RunCommand(getCommand);
                        this.res = cmd.Result;
                        ssh.Disconnect();
    
                    }
                return this.res;
                }

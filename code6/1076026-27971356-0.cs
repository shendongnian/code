            public void ExpectSSH (string address, string login, string password, string command)
        {
            try
            {
                SshClient sshClient = new SshClient(address, 22, login, password);
                sshClient.Connect();
                IDictionary<Renci.SshNet.Common.TerminalModes, uint> termkvp = new Dictionary<Renci.SshNet.Common.TerminalModes, uint>();
                termkvp.Add(Renci.SshNet.Common.TerminalModes.ECHO, 53);
                ShellStream shellStream = sshClient.CreateShellStream("xterm", 80,24, 800, 600, 1024, termkvp);
                
                
                //Get logged in
                string rep = shellStream.Expect(new Regex(@"[$>]")); //expect user prompt
                this.writeOutput(results, rep);
                //send command
                shellStream.WriteLine(commandTxt.Text);
                rep = shellStream.Expect(new Regex(@"([$#>:])")); //expect password or user prompt
                this.writeOutput(results, rep);
                //check to send password
                if (rep.Contains(":"))
                {
                    //send password
                    shellStream.WriteLine(password);
                    rep = shellStream.Expect(new Regex(@"[$#>]")); //expect user or root prompt
                    this.writeOutput(results, rep);
                }
                
                sshClient.Disconnect();      
            }//try to open connection
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

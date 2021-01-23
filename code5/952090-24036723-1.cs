    Sample:
     SshShell ssh; // create our shell
    
     ssh = new SshShell(aHost.host, aHost.username, aHost.password);
      
     // Command Output
      string commandoutput = string.Empty;
     // Remove Terminal Emulation Characters
      ssh.RemoveTerminalEmulationCharacters = true;
      // Connect to the remote server
      ssh.Connect();
      //Specify the character that denotes the end of response
      commandoutput = ssh.Expect(promptRegex);

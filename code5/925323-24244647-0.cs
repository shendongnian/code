If the system containing the remote log is a Linux box, use the cat command.
Assuming ssh is an instance of SshClient, something along the lines of the following will get the contents of a remote file:
    using (SshClient client = new SshClient(...))
    {
        client.Connect();
        using(SshCommand command = client.CreateCommand("cat printerimport_2014-02-28_03.21.41.log"))
        {
            label01.Text = command.Execute();
        }
    }  
  

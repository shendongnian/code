    private Database _database = new Database();
    
    private void LogonButton_Click(object sender, EventeArgs e)
    {
    	var logonResult = _database.Logon("username", "password");
    	if(logonResult) 
    	{
    		logon = DateTime.Now.ToString() + " - Username " + username + " just logged on";
    		listBox1.Items.Add(logon);
    	}
    }

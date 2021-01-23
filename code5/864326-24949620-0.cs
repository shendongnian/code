    private readonly ServiceController _sqlService = new ServiceController("MSSQL$SQLEXPRESS");
    
    // on login screen, I just saved the userRole of a Loggedin user in Session["userRole"]
    // On pageload, refresh the sql service and gets its current status.
    protected void Page_Load(object sender, EventArgs e)
    {
        _sqlService.Refresh();
        GetServiceCurrentStatus();
    
        // if userRole of loggedIn user is SuperAdmin, then it will make the buttons visible to the user
        // else it will hide the buttons and show only status of SQL SERVER to admin user and standard/limited user
    	if(Session["userRole"] == "SuperAdmin"){
    		this.btnStartServer.Visible = true;
    	    this.btnStopServer.Visible = true;
    	}
    	else{
    		this.btnStartServer.Visible = false;
    	    this.btnStopServer.Visible = false;
    	}
    	// You can further login to show hide Start Stop buttons
    }
    
    // Start Server Function
    protected void btnStartServer_Click(object sender, EventArgs e)
    {
        _sqlService.Refresh();
    
        if (_sqlService.Status == ServiceControllerStatus.Stopped)
        {
            _sqlService.Start();
            _sqlService.Refresh();
        }
        GetServiceCurrentStatus();
    }
    
    // Stop Server Function
    protected void btnStopServer_Click(object sender, EventArgs e)
    {
        _sqlService.Refresh();
        if (_sqlService.Status == ServiceControllerStatus.Running)
        {
            _sqlService.Stop();
            _sqlService.Refresh();
        }
        GetServiceCurrentStatus();
    }
    
    // Get Current Status of SQL Service Function
    private void GetServiceCurrentStatus()
    {
        try
        {
            _sqlService.Refresh();
    
            if (_sqlService.Status == ServiceControllerStatus.Running)
                this.txtServerStatus.Text = "SQL Server: Running";
            else if (_sqlService.Status == ServiceControllerStatus.Stopped)
                this.txtServerStatus.Text = "SQL Server: Stopped";
            else if (_sqlService.Status == ServiceControllerStatus.StartPending)
                    this.txtServerStatus.Text = "SQL Server: Starting...";
            else if (_sqlService.Status == ServiceControllerStatus.StopPending)
                this.txtServerStatus.Text = "SQL Server: Stopping...";
            else if (_sqlService.Status == ServiceControllerStatus.Paused || _sqlService.Status == ServiceControllerStatus.PausePending)
                this.txtServerStatus.Text = "SQL Server: Pause";
            else
                this.txtServerStatus.Text = "SQL Server: Processing";
        }
        catch (Exception)
        {
            this.txtServerStatus.Text = "SQL Server: Not Installed";
        }
    }
    
    // Timer Function
    protected void ServerTimer_OnTick(object sender, EventArgs e)
    {
        _sqlService.Refresh();
    }

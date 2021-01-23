    private readonly ServiceController _monitoringServer = new ServiceController("MONITORING$SERVER");
    
    // on login screen, I just saved the userRole of a Loggedin user in Session["userRole"]
    // On pageload, refresh the sql service and gets its current status.
    protected void Page_Load(object sender, EventArgs e)
    {
        _monitoringServer.Refresh();
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
        _monitoringServer.Refresh();
    
        if (_monitoringServer.Status == ServiceControllerStatus.Stopped)
        {
            _monitoringServer.Start();
            _monitoringServer.Refresh();
        }
        GetServiceCurrentStatus();
    }
    
    // Stop Server Function
    protected void btnStopServer_Click(object sender, EventArgs e)
    {
        _monitoringServer.Refresh();
        if (_monitoringServer.Status == ServiceControllerStatus.Running)
        {
            _monitoringServer.Stop();
            _monitoringServer.Refresh();
        }
        GetServiceCurrentStatus();
    }
    
    // Get Current Status of SQL Service Function
    private void GetServiceCurrentStatus()
    {
        try
        {
            _monitoringServer.Refresh();
    
            if (_monitoringServer.Status == ServiceControllerStatus.Running)
                this.txtServerStatus.Text = "Monitoring Server: Running";
            else if (_monitoringServer.Status == ServiceControllerStatus.Stopped)
                this.txtServerStatus.Text = "Monitoring Server: Stopped";
            else if (_monitoringServer.Status == ServiceControllerStatus.StartPending)
                    this.txtServerStatus.Text = "Monitoring Server: Starting...";
            else if (_monitoringServer.Status == ServiceControllerStatus.StopPending)
                this.txtServerStatus.Text = "Monitoring Server: Stopping...";
            else if (_monitoringServer.Status == ServiceControllerStatus.Paused || _monitoringServer.Status == ServiceControllerStatus.PausePending)
                this.txtServerStatus.Text = "Monitoring Server: Pause";
            else
                this.txtServerStatus.Text = "Monitoring Server: Processing";
        }
        catch (Exception)
        {
            this.txtServerStatus.Text = "Monitoring Server: Not Installed";
        }
    }
    
    // Timer Function
    protected void ServerTimer_OnTick(object sender, EventArgs e)
    {
        _monitoringServer.Refresh();
    }

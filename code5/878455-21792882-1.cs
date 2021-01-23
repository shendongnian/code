    protected void Page_Load(object sender, EventArgs e)
    {
        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<AlphaHub>();
        hubContext.Clients.All.CallForReport("Insured Report");
    }

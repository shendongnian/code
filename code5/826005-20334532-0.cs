    protected void Page_Load(object sender, EventArgs e)
    {
        using (var manager = ServerManager.OpenRemote("Lonappu01032"))
        {
            int filtered = Convert.ToInt32(Request.QueryString["filter"]);
            StringBuilder sb = new StringBuilder();
            foreach (WorkerProcess proc in manager.WorkerProcesses)
            {
                //your foreach remains unchanged
            }
        }
    }

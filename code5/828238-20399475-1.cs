    private void frmIni_Load(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() => {
            return SmoApplication.EnumAvailableServers(false);
        }).ContinueWith((task) => {
            foreach (var server in task.Result)
            {
                cboServer.Properties.Items.Add(server["Name"]);
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

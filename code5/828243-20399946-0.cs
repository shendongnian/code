    private void GetServers()
    {
        servers = SmoApplication.EnumAvailableSqlServers(false);
        // Thread.Sleep(1);
        foreach (DataRow server in servers.Rows)
        {
              cboServer.BeginInvoke((Action)(() => { cboServer.Properties.Items.Add(server["Name"]);}));
            // Thread.Sleep(1);
        }
    }

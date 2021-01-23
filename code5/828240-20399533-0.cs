    private void GetServers()
    {
        servers = SmoApplication.EnumAvailableSqlServers(false);
        Thread.Sleep(1); // Why?
        cboServer.BeginInvoke(
                (Action)(() => {
                    foreach (DataRow server in servers.Rows)
                    {
                        cboServer.Properties.Items.Add(server["Name"]);
                        Thread.Sleep(1); // Why?
                    }
                })
            );
    }

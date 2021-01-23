    cboServer.BeginInvoke(
        (Action)(() => {
            servers = SmoApplication.EnumAvailableSqlServers(false);
            Thread.Sleep(1);
            foreach (DataRow server in servers.Rows)
            {
                cboServer.Properties.Items.Add(server["Name"]);
                Thread.Sleep(1);
            }
        })
    );

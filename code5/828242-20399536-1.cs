    private void GetServers()
    {
           servers = SmoApplication.EnumAvailableSqlServers(false);
    
           cboServer.BeginInvoke(
              (Action)(() => {
                  foreach (DataRow server in servers.Rows)
                  {
                      cboServer.Properties.Items.Add(server["Name"]);
                  }
            }));
    }

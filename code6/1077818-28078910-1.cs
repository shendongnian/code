    private void button_kill_connection_Click(object sender, EventArgs e)
        {
            Object selectedConnection = null;
            selectedConnection = lbox_current_connections.SelectedItem;
            String selectedConnectionString = selectedConnection.ToString();
            for (int i = 0; i <= --sshClientIndex; i++)
            {
                
                if (sshClients[i].ConnectionInfo.Host == selectedConnectionString)
                {
                    sshClients[i].Disconnect();
                    lbox_current_connections.Items.Remove(selectedConnection);
                }
            }
        }

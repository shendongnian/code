    Microsoft.Data.ConnectionUI.DataConnectionDialog dlg = new Microsoft.Data.ConnectionUI.DataConnectionDialog();
            Microsoft.Data.ConnectionUI.DataSource.AddStandardDataSources(dlg);          
            if (Microsoft.Data.ConnectionUI.DataConnectionDialog.Show(dlg) == DialogResult.OK)
            {
            }

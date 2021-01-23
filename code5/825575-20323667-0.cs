    if (ddl.SelectedItem.ToString().Equals("it"))
        {
            ddlProv.Enabled = true;
           //add these two statements to enable
           PivaSize.Enabled=true;
           PivaErrata.Enabled=true;
        }
        else
        {
            ddlProv.SelectedIndex = 0;
            ddlProv.Enabled = false;
           
           //add these two statements to disable
           PivaSize.Enabled=false;
           PivaErrata.Enabled=false;
        }

               if (!IsPostBack)
                {
                    ddlDrives.Items.Clear();
                    ddlDrives.Items.Add("-Select-");
                    foreach (var d in DriveInfo.GetDrives())
                    {
                        ddlDrives.Items.Add(d.Name);
                    }
                }

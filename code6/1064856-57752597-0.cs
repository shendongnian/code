     private void BindVendorDDL()
            {
                ddlVendor.Items.Clear();
                DataTable dt = new DataTable();
                dt = bl.BindCompanyDLL();
                if (dt.Rows.Count > 0)
                {
                    ddlVendor.Text = "--Select--";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ddlVendor.Items.Add(dt.Rows[i]["Vendor_name"].ToString());
                    }
                }
            }

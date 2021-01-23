     foreach (DataGridViewRow dr in gvShipment.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dr.Cells["Select"];
                {
                    if (Convert.ToBoolean(chk.Value) == true)
                    {
                        IsApproved += dr.Cells["IsApproved"].Value.ToString() ;
                    }
                }
            }
            if (IsApproved == "False")
            {
                MessageBox.Show("This Order is not Approved.", "Message");
                return;
            }

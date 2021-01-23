       GridViewRow currentrow = (GridViewRow)((TextBox)sender).Parent.Parent.Parent.Parent;
            TextBox thisTextBox = (TextBox)currentrow.FindControl("txt_itemno");
            if (!string.IsNullOrWhiteSpace(thisTextBox.Text))
            {
                int row = currentrow.RowIndex;
                //rowChanged[row] = true;
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AWCC"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT ITEMDET.ITEMDESC,RGITEMDET.UNITCOST FROM ITEMDET JOIN RGITEMDET ON RGITEMDET.ITEMNO=ITEMDET.ITEMNO WHERE ITEMDET.ITEMNO ='" + thisTextBox.Text + "' ", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ((Label)(grv_gindet.Rows[row].FindControl("txt_itemdesc"))).Text = dr["ITEMDESC"].ToString();
                        ((TextBox)(grv_gindet.Rows[row].FindControl("txt_ucost"))).Text = dr["UNITCOST"].ToString();
                    }
                    con.Close();
                }
                thisTextBox.Enabled = false;
            }

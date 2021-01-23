    foreach (TabPage tp in tabControl1.TabPages)
                {
                    con.Open();
    				SqlDataAdapter sdaProductType =  new SqlDataAdapter("SELECT ProductType FROM TblProductType WHERE Description =\"" + tp.Text + "\"", con);
    				DataTable dtForProductType = new DataTable();
    				sdaProductType.Fill(dtForProductType);
    				string currentProductType = dtForProductType.Rows[0]["ProductType"];
    				SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT Description FROM TblProducts WHERE ProductType =" + currentProductType, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
    
                    FlowLayoutPanel flp = new FlowLayoutPanel();
                    flp.Dock = DockStyle.Fill;
    
                    foreach (DataRow dr in dt.Rows)
                    {
                        Button b = new Button();
                        b.Size = new Size(100, 100);
                        b.Text = dr["Description"].ToString(); 
                        flp.Controls.Add(b);
                    }
    
                    tp.Controls.Add(flp);
                    con.Close();
                }

    private void AddProductsToTabbedPanel()
        {
            int i = 1;
            
            foreach (TabPage tp in tabControl1.TabPages)
            {
                con.Open();
                SqlDataAdapter sdaProductType = new SqlDataAdapter("SELECT Description FROM TblProducts WHERE ProductType =" + i.ToString(), con);
                
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Dock = DockStyle.Fill;
                DataTable dt = new DataTable();
                sdaProductType.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Button b = new Button();
                    b.Size = new Size(100, 100);
                    b.Text = dr["Description"].ToString();
                    flp.Controls.Add(b);
                }
                tp.Controls.Add(flp);
                i++;
                con.Close();
            }
        }

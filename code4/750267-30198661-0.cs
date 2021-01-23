     private void AddProductsToPannel()
        {
            int i = 1;
            foreach (TabPage tp in tabcon_ProductList.TabPages)
            {
                connection.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT DISTINCT Description FROM Tbl_Product Where ProductType =" + i, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                FlowLayoutPanel flowLayout = new FlowLayoutPanel();
                flowLayout.Dock = DockStyle.Fill;
                foreach (DataRow dr in dt.Rows)
                {
                    Button b = new Button();
                    b.Size = new Size(100, 100);
                    b.Text = dr["Description"].ToString(); 
                    flowLayout.Controls.Add(b);
                }
                tp.Controls.Add(flowLayout);
                connection.Close();
                i++;
            }

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Stocks;Integrated Security=True;Pooling=False");
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [Stocks].[dbo].[product]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = DataGridView1.Rows.Add();
                DataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                DataGridView1.Rows[n].Cells[1].Value = item["Productname"].ToString();
                DataGridView1.Rows[n].Cells[2].Value = item["qty"].ToString();                
                if ((bool)item["productstatus"])
                {
                    DataGridView1.Rows[n].Cells[3].Value = "Active";
                }
                else
                {
                    DataGridView1.Rows[n].Cells[3].Value = "Deactive";
                }
                       

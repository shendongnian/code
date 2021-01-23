            DataTable dt =new DataTable();
            dt.Rows.Add();
            dt.Columns.Add(TextBox1.Text);
            GridView1.DataSource =dt;
            GridView1.DataBind();

            string src = @"C:\SampleData\us-500.xls";
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + src +
                                              ";Extended Properties=Excel 8.0;");
            //con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from [MySheet$]", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = ds.Tables[0];
            var dataGridView1 = new DataGridView();
            // Add data grid view as child control on form, flow Layout Panel is placed on windows form 
            flowLayoutPanel1.Controls.Add(dataGridView1);
            dataGridView1.DataSource = bindingSource;
            int rows = dataGridView1.Rows.Count;
            int cells = dataGridView1.Rows[0].Cells.Count;

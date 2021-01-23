    string C = ConfigurationManager.ConnectionStrings[""].ConnectionString;
        SqlConnection con = new SqlConnection(C);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = ("SELECT ... WHERE TableName = cb1.SelectedValue");
          spProc & fill it in the DT
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            cbTbl.DisplayMember = "TABLE_NAME";
            cbTbl.ValueMember = "TABLE_NAME";
            cbTb2.DataSource = dt;

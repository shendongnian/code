       public void Button(TextBox textId, TextBox txtFirstname, TextBox txtLastname)
        {
          myCon.connectionString();
          string SomeString = string.Empty;
          SqlConnection cnn = myCon.Con;
          cnn.Open();
          {
            CmdString = "SELECT * FROM TableA";
            SqlCommand cmd = new SqlCommand(CmdString, cnn.Con);
            adapter = new SqlDataAdapter(cmd);
            ds = new DataSet();
            adapter.Fill(ds, "Table");
            txtId.Text = ds.Tables[0].Rows[rno][0].ToString();
            txtFirstname.Text = ds.Tables[0].Rows[rno][1].ToString();
            txtLastname.Text = ds.Tables[0].Rows[rno][2].ToString();
          }
     }

    OleDbCommand cmd = new OleDbCommand();
    if (TextBox1.Text == null || TextBox1.Text == "")
    {
        Response.Write("Enter Email");
    }
    foreach (ListItem li in CA.Items)
    {
        if (li.Selected == true)
        {
            cmd.CommandText = "INSERT INTO USR_MNU(LNK_NAME,USR_EMAIL,ACTIVE) values('" + li.Value + "','" + TextBox1.Text + "',1)";
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }

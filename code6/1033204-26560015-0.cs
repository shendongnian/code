    string strConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=access.mdb";
    if (e.KeyCode == Keys.Enter)
    {
        e.Handled = true;
        e.SuppressKeyPress = true;
        using(OLeDbConnection = conn = new OleDbConnection(strConnectionString))
        using(OleDbCommand cmd = new SqlCommand("select [PASSWORD] from regulate where NAME = @ID", conn);
        {
                cmd.Parameters.AddWithValue("@ID", txtName.Text);
                conn.Open();
                using(OleDbDataReader dr = cmd.ExecuteReader())
                {
                     ......... read your data .....
                }
         }
     }

    protected void Button3_Click(object sender, EventArgs e)
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\ASPNetDB.mdb;Persist Security Info=True");
        {
            da.InsertCommand = new OleDbCommand("INSERT INTO UserProfile (Rented) VALUES (?) WHERE [UserName] = ?", conn);
            da.InsertCommand.Parameters.AddWithValue("@Rented", DG_Latest.SelectedRow.Cells[2].Text);
            da.InsertCommand.Parameters.AddWithValue("@User", XXXXXXXXX);
            conn.Open();
            da.InsertCommand.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
    }

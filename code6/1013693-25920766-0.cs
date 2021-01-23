    private void SomeOtherMethod()
    {
        string connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Path\\database_be.accdb;Persist Security Info=False;";
        using(var conn = new OleDbConnection(connectionstring))
        {
            conn.Open();
            ApplyUpdates(conn);
        } //The using statement closes the connection for you. 
    }
    private void ApplyUpdates(OleDbConnection conn)
    {
         var sql = "Update UserList SET ActiveToday=@ActiveToday WHERE POID=@POID";
         foreach (DataGridViewRow row in dataGridView1.Rows)
         {
              using(var myCommand = new OleDbCommand(sql, conn);
              {
                  myCommand.CommandType = CommandType.Text; //I think it is text by default and this is unnessary
                  myCommand.Parameters.AddWithValue("@ActiveToday", 1);
                  myCommand.Parameters.AddWithValue("@POID", row.Cells["POID"].Value.ToString());
                  myCommand.ExecuteNonQuery();
              }
        }
    }

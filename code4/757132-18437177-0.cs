    string columnName = string.Empty;
    if(myComboBox.SelectedIndex == 0)
      columnName = "column1";
    else if(myComboBox.SelectedIndex == 1)
      columnName = "column1";
    
    string myValue = "assign your value here";
    string insertStatement = "insert into myTable("+columnName+") values(@param1)";
    
    using(SqlConnection sqlCon = new SqlConnection("ConnectionString"))
    {
        sqlCon.Open();  
        SqlCommand cmd = new SqlCommand(insertStatement,sqlCon);
        cmd.Parameters.Add("@param1", SqlDbType.Varchar, 50).value = myValue;
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
    }

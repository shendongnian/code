     Public void HasRows(SqlConnection connection)
     {
      using (connection)
        {
        DateTime StartDate=Date.Parse(textBox1.text.ToString());
        DateTime EndDate=Date.Parse(textBox2.text.ToString());
        String StrQuery="select *  from <TableName> where  DateColumn between
         '"+ StartDate.ToString("yyyy-MM-dd") +"' and '"+ EndDate.ToString("yyyy-MM-dd")                  +"'";
        SqlCommand command = new SqlCommand(StrQuery,  connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
              Label1.Text=reader["field_a"].ToString();//date should be display in label
              txtBox3.Text=reader["field_b".ToString(); //date should be display in textbox
            }
        }
        else
        {
          Response.Write("No Data Found");
        }
        reader.Close();
    }
}

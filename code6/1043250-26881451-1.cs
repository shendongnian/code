    using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP\SQLEXPRESS;initial catalog=SO;trusted_connection=true"))
    {
       SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Student", connection);
       adapter.InsertCommand = new SqlCommand("InsertStudent", connection);
       adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
       adapter.InsertCommand.Parameters.Add("@_Name", SqlDbType.NChar, 15, "Name");
       adapter.InsertCommand.Parameters.Add("@_address", SqlDbType.NChar, 45, "Address");
       DataTable students = new DataTable();
       adapter.Fill(students);
       // Add a new row.
       DataRow sRow = students.NewRow();
       sRow["Name"] = "John";
       sRow["Address"] = "Paris";
       students.Rows.Add(sRow);
       adapter.Update(students);
     }

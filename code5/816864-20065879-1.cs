     SqlCommand command = new SqlCommand("InsertTable");
     command.CommandType = CommandType.StoredProcedure;
     var dt = new DataTable(); //create your own data table
     command.Parameters.Add(new SqlParameter("@myTableType", dt));
     command.ExecuteNonQuery();

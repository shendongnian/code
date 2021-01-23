    SqlParameter fileP = new SqlParameter("@Upload", SqlDbType.VarBinary);
    fileP.Value = bytes; //Here, you're assigning the value to the parameter.
    SqlCommand myCommand = new SqlCommand();
    myCommand.Connection = someSqlConnection;
    myCommand.CommandText = "YOUR UPDATE STATEMENT";
    myCommand.Parameters.Add(fileP);
    myCommand.ExecuteNonQuery();
    

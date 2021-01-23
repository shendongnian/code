    byte[] fileBytes=System.IO.File.ReadAllBytes("path to file");
    System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("insert  into table(blob,filename) values (@blob,@name)");
    command.Parameters.AddWithValue("blob", fileBytes);
    command.Parameters.AddWithValue("name", "filename");
    command.ExecuteNonQuery();

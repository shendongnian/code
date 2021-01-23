    using (SqlConnection conn = new SqlConnection(SQLSrc.ConnectionString))
    using (SqlCommand command = conn.CreateCommand())
    {
       command.CommandText = "SELECT FileName, MimeType, FileBytes FROM Attachments WHERE PK = @PK";
       command.Parameters.AddWithValue("@PK", Request.QueryString["pk"]);
       
       conn.Open();
       using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection))
       {
          if (reader.Read())
          {
             string name = reader.GetString(reader.GetOrdinal("FileName"));
             Response.AppendHeader("Content-Disposition", "attachment; filename=" + name);
             Response.ContentType = reader.GetString(reader.GetOrdinal("MimeType"));
             
             int startIndex = 0;
             byte[] buffer = new byte[4096];
             int fieldIndex = reader.GetOrdinal("FileBytes");
             int bytesRead = (int)reader.GetBytes(fieldIndex, startIndex, buffer, 0, buffer.Length);
             while (bytesRead != 0)
             {
                Response.OutputStream.Write(buffer, 0, bytesRead);
                Response.Flush();
                
                startIndex += bytesRead;
                bytesRead = (int)reader.GetBytes(fieldIndex, startIndex, buffer, 0, buffer.Length);
             }
          }
       }
    }

    // assumption is that the dropdown values contain a key to the file
    // contents (resume) in the DB and the contents are retrieved as a 
    // byte array.
    
    if (lstFiles != null)
    {
     foreach (var fileName in lstFiles)
     {
      int cvId = 42; // can come from dropdown etc. basically a key to the file.
      byte[] resumeBytes = GetResumeFromDatabaseAsBytes(cvId);
      email.Attachments.Add(new Attachment(new MemoryStream(resumeBytes, fileName)));
     }
    }
    public static byte[] GetResumeFromDatabaseAsBytes(int cvID)
    {
     var connectionString = "YOUR_CONNECTION_STRING";
    
     using (var sqlConnection = new SqlConnection(connectionString))
     {
         using (var sqlCommand = new SqlCommand("SELECT TOP 1 FileName, FileType, Data From  RESUME_TABLE_NAME Where cvID = " + cvID, sqlConnection))
        {
            using (var reader = sqlCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    // e.g. John_Doe.docx
                    string fileName = reader["FileName"].ToString() + "." + reader["FileType"].ToString();
                    byte[] cvData = (byte[])reader["Data"];
    
                    //return cvData;
                }
            }
        }
     }
    }

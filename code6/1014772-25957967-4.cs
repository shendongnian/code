    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string pdfUrl = string.Empty;
        string imgUrl = string.Empty;
        // Using a parameterized query to avoid malicious user text that could wreak havoc....
        // Sql Injection is a serious problem. Always use a parameterized query......
        string cmdText = @"SELECT PDFUrl, ImgUrl FROM Book WHERE Id=@id";
        // Enclose disposable objects in a using statement 
        // DO NOT KEEP a global connection object... there is the connection pool
        using(SqlConnection con = new SqlConnection(.....connectionstringhere....))
        using(SqlCommand cmd = new SqlCommand(cmdText, con))
        {
            con.Open();
            cmd.Parameters.AddWithValue("@id", TextBoxDelete.Text.Trim());
    
            // ask the command to create a reader for us....
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                // Check if a record is returned by the reader
                if(reader.Read())
                {
                   // OK we could get it but not if it is DBNull.....
                   pdfUrl = reader.IsDbNull(0) ? string.Empty : reader[0].ToString();
                   imgUrl = reader.IsDbNull(1) ? string.Empty : reader[1].ToString();
    
                   // Prepare the full path for the two files...
                   string fullPathPDF = pdfUrl.Length > 0 ? Server.MapPath(pdfUrl) : string.Empty;
                   string fullPathImg = imgUrl.Length > 0 ? Server.MapPath(imgUrl) : string.Empty;
                   // Start deleting them
                   if (File.Exists(fullPathPDF))
                       File.Delete(fullPathPDF);
                   if (File.Exists(fullPathImg))
                       File.Delete(fullPathImg);
    
                   // CLOSE THE READER BEFORE EXECUTING ANOTHER COMMAND
                   // This could be removed if your connection string uses 
                   // MultipleActiveResultSets=True   (MARS)
                   reader.Close();
                   // The parameter is still there, the command is still linked to the connection
                   // Just change the commandtext and execute....
                   cmd.CommandText = "DELETE FROM Book WHERE Id=@id";
                   cmd.ExecuteNonQuery();
                }
            }
        }
    }

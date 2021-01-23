    int length = FileUpload.PostedFile.ContentLength;
    byte[] picSize = new byte[length];
    HttpPostedFile uplImage= FileUpload.PostedFile;
    uplImage.InputStream.Read(picSize, 0, length);
    using (SqlConnection con = new SqlConnection(connectionString))
    {
    	SqlCommand com = new SqlCommand("INSERT INTO [Table] (Name, Picture) values (@Name, @Picture)", con);
    	try
    	{
    		com.Parameters.AddWithValue("@Name", TextName.Text);
    		com.Parameters.AddWithValue("@Picture", picSize);
    		com.ExecuteNonQuery();
    	}
    	catch (SqlException ex)
    	{
    		for (int i = 0; i < ex.Errors.Count; i++)
    		{
    			errorMessages.Append("Index #" + i + "\n" +
    				"Message: " + ex.Errors[i].Message + "\n" +
    				"LineNumber: " + ex.Errors[i].LineNumber + "\n" +
    				"Source: " + ex.Errors[i].Source + "\n" +
    				"Procedure: " + ex.Errors[i].Procedure + "\n");
    		}
    		Console.WriteLine(errorMessages.ToString());
    	}
    }

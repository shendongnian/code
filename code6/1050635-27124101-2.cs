      byte[] image = GetImage(photoFilePath);
    
      using (SqlConnection connection = new SqlConnection(connectionString)){
    
          SqlCommand command = new SqlCommand("INSERT INTO Employees (Image) " +
            "Values(@Image)", connection); 
    
          command.Parameters.Add("@Image", SqlDbType.Image, image.Length).Value = image;
          connection.Open();
          command.ExecuteNonQuery();
      }

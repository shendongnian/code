      byte[] photo = GetPhoto(photoFilePath);
    
      using (SqlConnection connection = new SqlConnection(connectionString)){
    
          SqlCommand command = new SqlCommand("INSERT INTO Employees (Photo) " +
            "Values(@Photo)", connection); 
    
          command.Parameters.Add("@Photo", SqlDbType.Image, photo.Length).Value = photo;
          connection.Open();
          command.ExecuteNonQuery();
      }

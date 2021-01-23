       string connString = "Server=localhost;database=abcd;uid=abcd;password=abcd";
        try
         {
          using (MySqlConnection mcon  = new MySqlConnection(connString))
            {
              using (MySqlCommand cmd = mcon.CreateCommand())
               {
                 mcon.Open();
                 cmd.CommandText = @"INSERT INTO `contentupload`.`content_document`
                   (
                   `content`)
                   VALUES (@content);";
                   cmd.Parameters.AddWithValue("@content", content);
                   cmd.ExecuteNonQuery();
                   long imageId = cmd.LastInsertedId;
                   Response.Redirect("YourPage.aspx?imageID="+imageId.ToString());
                   }
                  }
                 }
    
        catch (MySqlException e)
        {
            return ;
        }
    
    }

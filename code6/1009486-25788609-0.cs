    public FileStreamResult GetDBImage(string imageId)
    {
      using (var conn = GetConnection())
      {
        conn.Open();
        using (var cmd = conn.CreateCommand)
        {
          cmd.CommandText = "SELECT ITEM_IMAGE FROM ... WHERE id=@id";
          cmd.Parameters.Add("@id", imageId);
          using (var rdr = cmd.ExecuteReader())
            return File(rdr.GetStream(0), "image/png")
        }
      }  
    }

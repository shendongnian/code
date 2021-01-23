    public List<ImageInfo> GetImages()
    {
        var imageList = new List<ImageInfo>();
        string sql = "SELECT * FROM images";
        using (var conn = new MySqlConnection(/*Connection String*/))
        { 
            conn.Open();
            using (var cmd  = new MySqlCommand(sql, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                      while (reader.Read())
                      {
                           var imageInfo = new ImageInfo();
                           imageInfo.Id = Convert.ToInt32(reader["id"]);
                           imageInfo.Img_name = Convert.ToString(reader["img_name"]);
                           imageInfo.Img_alt = Convert.ToString(reader["img_alt"]);
                           imageInfo.FK_album = Convert.ToInt32(reader["FK_album"]);
                           imageList.Add(imageInfo);
                      }
                }
            }
        }
        return imageList;
    }

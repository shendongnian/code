    MySqlCommand cmd = new MySqlCommand("insert into Fn_Pictures(Images,Email)values(?Images,'" + txtEmailIdText + "')", cn);
         
    MySqlParameter parImage = new MySqlParameter();
    parImage.ParameterName = "?Images";
    parImage.MySqlDbType = MySqlDbType.MediumBlob;
    parImage.Size = 3000000;
    parImage.Value = ImageData;//here you should put your byte []
    cmd.Parameters.Add(parImage);
    cmd.ExecuteNonQuery();

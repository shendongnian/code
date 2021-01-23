    string query = @"UPDATE dbo.IMAGE
                      SET PIXEL_HEIGHT = @Height, PIXEL_WIDTH = @Width,SIZE = @Size
                      WHERE IMAGE_NO = @ImageNo";
    using (var cn = new SqlConnection("connection string here") )
    using (var cmd = new SqlCommand(query, cn))
    {
        //guessing at the types. Use the exact column types from your database
        cmd.Parameters.Add("@Height", SqlDbType.Int).Value = Height;
        cmd.Parameters.Add("@Width", SqlDbType.Int).Value = Width;
        cmd.Parameters.Add("@Size", SqlDbType.Int).Value = Size;
        cmd.Parameters.Add("@ImageNo", SqlDbType.Int).Value = imageNo;
        cn.Open();
        cmd.ExecuteNonQuery();
    }

    String query = "UPDATE News SET postimage = @postImage, Image = @Image WHERE id=@id";
    SqlCommand myCommand = new SqlCommand(query, myConnection);
    myCommand.Parameters.AddWithValue("@postImage",postImage ?? DBNull.Value);
    myCommand.Parameters.AddWithValue("@Image",Image ?? DBNull.Value);
    myCommand.Parameters.AddWithValue("@id",id);
    myCommand.ExecuteNonQuery();
    myConnection.Close();

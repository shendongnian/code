    DateTime date = DateTime.ParseExact(txtDate1.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
    string strQuery = "SELECT Story.UserName, Story.StoryId, COUNT(Likes.StoryID) AS NumberOfOrders 
        FROM Likes LEFT JOIN Story ON Likes.StoryId=Story.StoryId and liked=@dateTime
        GROUP BY Story.StoryId,Story.UserName order by NumberOfOrders DESC";
    using (SqlConnection connection = new SqlConnection("..."))
    {
        using (SqlCommand cmd = new SqlCommand(strQuery, connection))
        {
            cmd.Parameters.AddWithValue("@dateTime", date);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            ...
        }
    }

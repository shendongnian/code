    SqlConnection myConnection = new SqlConnection("your connection string");
    myConnection.Open();
    string id = "my_id";
    string text;
    string fileName;
    SqlCommand query = new SqlCommand();
    query.CommandText = "SELECT FileName, SubtitleText FROM Subtitles WHERE ID = '@id'";
    query.Parameters.AddWithValue("@id", id);
    query.Connection = myConnection;
    SqlDataReader data = query.ExecuteReader(); 
    while (data.Read()) {
    text = (string)data["SubtitleText"];
    fileName = (string)data["FileName"];
    }
    using (FileStream fs = File.Create(file + ".srt")) {
    File.WriteAllText(file, text);
    }

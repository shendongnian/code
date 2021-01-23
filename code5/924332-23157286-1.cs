    public struct Video
    {
        public int ID;
        public string Name;
        public int Count;
    }
    
    static void Main(string[] args)
    {
        string myConnectionString = "YOUR_CONNECTION_STRING";
        SqlConnection myConn = new SqlConnection(myConnectionString);
        SqlCommand myCommand = new SqlCommand("SELECT ID, VideoName, VideoPlayCount FROM dbo.VideoTable WHERE Id = YOUR_VIDEO_RECORD_ID", myConn);
        Video video = new Video();
    
        myCommand.CommandType = System.Data.CommandType.Text;
    
        myConn.Open();
        SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.SingleResult);
        reader.Read();
        video.ID = reader.GetInt32(0);
        video.Name = reader.GetString(1);
        video.Count = reader.GetInt32(2);
        myConn.Close();
    
        string myTextBoxValue = video.Name + " " + video.Count.ToString();
    }

    private static void Stream_FilteredStreamExample()
    {
        var stream = Stream.CreateFilteredStream();
        stream.AddTrack("ebola");
        stream.MatchingTweetAndLocationReceived += (sender, args) =>
        {
            if (!args.Tweet.IsRetweet)
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=xxxx;Initial Catalog=Surveillance;Integrated Security=True"))
                {
                conn.Open();
                var tweet = args.Tweet;
                if(args.Tweet.Coordinates!=null)
                {
                    using (SqlCommand myCommand = new SqlCommand("INSERT INTO TwitterDatabase(Tweet,Latitude,Longitude) values '"+tweet.Text+"','"+tweet.Coordinates.Latitude+"','"+tweet.Coordinates.Longitude+"')",conn))
                    {
                        myCommand.ExecuteNonQuery();
                    }
                 }
                 }
            }
        };
      stream.StartStreamMatchingAnyCondition();
    }

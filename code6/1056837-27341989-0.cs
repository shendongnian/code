    stream.MatchingTweetAndLocationReceived += (sender, args) =>
            {
                if (!args.Tweet.IsRetweet)
                {
                    using ( SqlConnection conn = new SqlConnection(@"Data Source=WIN-PAL1Q8DR163\AVINASH;Initial Catalog=Surveillance;Integrated Security=True"))
                    {
                    conn.Open();
                    var tweet = args.Tweet;
                    if (args.Tweet.Coordinates != null)
                    {
                        try
                        {
                            using (SqlCommand myCommand = new SqlCommand("INSERT INTO TwitterDatabase(Tweet,Latitude,Longitude) VALUES(@Tweeets, @LatCoordinate, @LongCoordinate)", conn))
                            {
                                myCommand.Parameters.Add(new SqlParameter("Tweeets", tweet.Text));
                                myCommand.Parameters.Add(new SqlParameter("LatCoordinate", tweet.Coordinates.Latitude));
                                myCommand.Parameters.Add(new SqlParameter("LongCoordinate", tweet.Coordinates.Longitude));
                                myCommand.ExecuteNonQuery();
                            }
                        }catch{
                            Console.WriteLine("Could not insert.");
                        }
                    }
                        
                }
        }
                
            };
        stream.StartStreamMatchingAnyCondition();
        
    }
       
     }
    }

    priavte async Task UploadVideoAsync(TwitterContext twitterCtx)
    {
                    var additionalOwners = new List<ulong> { 3265644348, 15411837 };
                    string status =
                        "Testing video upload tweet #Linq2Twitter £ " +
                        DateTime.Now.ToString(CultureInfo.InvariantCulture);
        
                    var media = await twitterCtx.UploadMediaAsync(
                        File.ReadAllBytes(@"..\..\images\SampleVideo.mp4"), "video/mp4");
        
                    Status tweet = await twitterCtx.TweetAsync(status, new ulong[] { media.MediaID });
        
                    if (tweet != null)
                        Console.WriteLine("Tweet sent: " + tweet.Text);
    }

    // last tweet processed on previous query set
    ulong sinceID = 210024053698867204;
 
    ulong maxID;
    const int Count = 10;
    var statusList = new List<status>();
 
    var userStatusResponse =
        (from tweet in twitterCtx.Status
         where tweet.Type == StatusType.User &&
           tweet.ScreenName == "JoeMayo" &&
           tweet.SinceID == sinceID &&
           tweet.Count == Count
         select tweet)
        .ToList();
 
    statusList.AddRange(userStatusResponse);
 
    // first tweet processed on current query
    maxID = userStatusResponse.Min(
        status => ulong.Parse(status.StatusID)) - 1;
 
    do
    {
        // now add sinceID and maxID
        userStatusResponse =
            (from tweet in twitterCtx.Status
             where tweet.Type == StatusType.User &&
                   tweet.ScreenName == "JoeMayo" &&
                   tweet.Count == Count &&
                   tweet.SinceID == sinceID &&
                   tweet.MaxID == maxID
             select tweet)
            .ToList();
 
        if (userStatusResponse.Count > 0)
        {
            // first tweet processed on current query
            maxID = userStatusResponse.Min(
                status => ulong.Parse(status.StatusID)) - 1;
 
            statusList.AddRange(userStatusResponse); 
        }
    }
    while (userStatusResponse.Count != 0 && statusList.Count < 30);

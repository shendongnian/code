    foreach (string s in namearry)
    {
        try
        {
            var timelineData = oAuthTwitterWrapper.GetMyTimeline(s);
            TwitterData.TimeLineData(timelineData, s, int.Parse(dr["ClientId"].ToString()));
            //  var followersId = oAuthTwitterWrapper.GetFolowersId(s);
            // var loc = oAuthTwitterWrapper.GetFolowersLoc(followersId);
            //  TwitterData.Follower(loc, s);
        }
        catch(Exception exp)
        {
        }
    }

    try{
    //making name array and other checks, that may trigger exceptions
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
            catch(Exception ex)
            {
                //logging exception: this will override the outer handler, which will not be called.
            }
        }
    }
    catch(Exception ex){
        //logging exception
        //exceptions raised before entering the foreach are handled here
    }

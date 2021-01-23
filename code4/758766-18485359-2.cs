    foreach (string s in namearry)
    {
        try
        {
            var timelineData = oAuthTwitterWrapper.GetMyTimeline(s);
            if(timelineData!=null)
            {
                 int clientID;
                 if(int.TryParse(dr["ClientId"].ToString(), out clientID))
                 {
                      TwitterData.TimeLineData(timelineData, s, clientID);            
                 }
            }
        }
        catch(Exception exp)
        {
            //do logging here.
        }
    }

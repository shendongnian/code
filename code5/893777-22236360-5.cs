    var maxNumberOfTries = 3;
    var currentTry = 0;
    var flag = false;
    do
    {
        currentTry += 1;
        try
        {
            mySearchResults = getResults(searchPacket.ToString());
            vbResultz += Server.HtmlEncode(mySearchResults) ;
            flag = true;
        }
        catch (WebException wx)
        {
            HttpWebResponse webresponse ;
            webresponse = (HttpWebResponse)wx.Response;
    
            switch (webresponse.StatusCode)
            {
               case HttpStatusCode.InternalServerError:
                ...
                    flag = true;
                    break;
    
                case HttpStatusCode.Forbidden: // 403
                    vbResultz = "You aint got no valid session key!";
                  // code here to get a new session key and try again
    
                    break;
    
                default:
                    throw;
            }
        }
        if (flag) break;
    } while (currentTry <= maxNumberOfTries)
    if (!flag)
    {
        // If code reaches here, whatever had to be done has been tried <maxNumberOfTries> times and did not work
    }

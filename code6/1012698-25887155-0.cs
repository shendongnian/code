    pl_wReqData.CookieContainer = new CookieContainer();
    pl_wResData = (HttpWebRespons)pl_wReqData.GetResponse();
    
    if(pl_wResData.StatusCode.Equals(HttpStatusCode.OK))
    {
        strSID = pl_wResData.Cookies["SESSION_ID"].Value;
    }

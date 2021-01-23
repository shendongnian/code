    try
    {
        //execute when the application closed 
        Application.Lock();
        Dictionary<string, VisitorUser> dic = new Dictionary<string, VisitorUser>();
        dic = (Dictionary<string, VisitorUser>)Application["MeetUsers"];
        if (dic != null)
        {
            StringBuilder sbVisitor = new StringBuilder();
            foreach (KeyValuePair<string, VisitorUser> key in dic)
            {
                VisitorUser vu = key.Value;
                sbVisitor.Append(" select '" + vu.UserName + "','" + vu.ImgUrl + "','" + vu.NickName + "'," + vu.LoginTime + " union ");
            }
            new VipUserBLL().BackUpVisitor(sbVisitor.ToString().Trim().Trim("union".ToCharArray()));
        }
    }
    catch (Exception E)
    {
        // log error, you can put a break point here when debugging.
    }
    finally
    {
        Application.UnLock();
    }

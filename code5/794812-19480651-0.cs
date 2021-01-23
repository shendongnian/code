    sqlcomm.CommandText = "Select * From QF where Question=@Question And qtags=@Qtags And UserFullName=@UserName And AID1=@AID1 And AID2=@AID2 And AID3=@AID3";
    
    sqlcomm.Parameters.Add(new SqlParameter("@Question", Server.UrlDecode(Request.QueryString["Question"])));
    sqlcomm.Parameters.Add(new SqlParameter("@Qtags", Server.UrlDecode(Request.QueryString["Questiontags"])));
    sqlcomm.Parameters.Add(new SqlParameter("@UserName", Server.UrlDecode(Request.QueryString["Askedby"])));
    sqlcomm.Parameters.Add(new SqlParameter("@AID1", Server.UrlDecode(Request.QueryString["AID1"])));
    sqlcomm.Parameters.Add(new SqlParameter("@AID2", Server.UrlDecode(Request.QueryString["AID2"])));
    sqlcomm.Parameters.Add(new SqlParameter("@AID3", Server.UrlDecode(Request.QueryString["AID3"])))
;

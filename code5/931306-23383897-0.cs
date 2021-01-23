    Page-load()
    {
     if(string.IsNullorEmpty(Request.QueryString("CONFERENCEID").Tostring()))
     {
        Response.Redirect("Default.aspx?CONFERENCEID="+ 3)
     }
       string value=Request.QueryString("CONFERENCEID").Tostring()
    }

    Page-load()//Point 1
    {
     if(string.IsNullorEmpty(Request.QueryString("CONFERENCEID").Tostring()))// Point 3
     {
        Response.Redirect("Default.aspx?CONFERENCEID="+ 3);
     }
       string value=Request.QueryString("CONFERENCEID").Tostring()//Point 2
    }

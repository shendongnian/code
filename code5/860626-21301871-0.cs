    try
    {
         if(Session["Username"] != null)
             Username = Session["Username"].ToString();
    }
    catch(Exception e)
    {
      Username = "";
    }

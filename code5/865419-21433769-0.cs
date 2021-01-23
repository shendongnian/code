    if (Session != null)
    {
        if(Session["object"] == null)
        {
             Session["object"] = GetObject();
             return Session["object"] as List<object>;
        }
        else
        {
            return Session["object"] as List<object>;
        }
    }
    else
    {
        return null;
    }

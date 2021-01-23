    if (Username == "You" || Username == "you")
    {
       Response.Redirect("~/you.aspx");
    }
    else if (Username == "Me" || Username == "me")
    {
       Response.Redirect("~/me.aspx");
    }
    else if (Username == "Them" || Username == "them")
    {
       Response.Redirect("~/Them.aspx");
    }

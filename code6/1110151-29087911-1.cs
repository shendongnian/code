    if (Session["AbonnementsId"] != null)
    {
        _subscriptionId = long.Parse(Session["AbonnementsId"].ToString());
    }
    else
    {
        //when I need to print my class do I like it here
        _subscriptionId = AbonnementsId.GetAbonnementsId();
    }

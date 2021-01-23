    if (getUserRole(Convert.ToString(Session["UserId"])) == "HR")
    {
        //hide Log Tickets tab
        liLogTickets.Visible = false;
        divLogTickets.Visible = false;
    }

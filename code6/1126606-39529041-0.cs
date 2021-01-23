    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "myCommand")
        {
            string myID = e.CommandArgument.ToString();
        }
    }

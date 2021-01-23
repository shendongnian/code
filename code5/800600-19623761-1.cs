    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "cmd")
        {
            //set a break point in the next line
            string myString = e.CommandName;
        }
    }

    override protected void OnInit(EventArgs e)
    {
       base.OnInit(e);
       Repeater1.ItemCommand += new RepeaterCommandEventHandler(Repeater1_ItemCommand);
    }
 
    private void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
            switch (e.CommandName)
            {
                case "mail":
                    string emailId = e.CommandArgument.ToString();
                    break;
            }
    }

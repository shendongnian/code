    btn.Command += new CommandEventHandler(b_Command); //handler
    btn.CommandName = "foo";
    Public void b_Command(object sender, CommandEventArgs e)
    {
        if(e.CommandName == "foo")
        {
            //Do stuff
        }
    }

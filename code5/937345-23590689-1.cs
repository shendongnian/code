    TextBox t1;
    TextBox t2;
    string rollNumber, T1, T2;
    if (e.CommandName == "add")
    {
        // get CommandArgument you have selected on the button
        string roll = e.CommandArgument.ToString();
        rollNumber = roll;
        foreach (RepeaterItem item in Repeater1.Items)
        {
            t1 = (TextBox)item.FindControl("quiz1");
            t2 = (TextBox)item.FindControl("quiz2");
            T1 = t1.Text;
            T2 = t2.Text;
            //...DB code or any other code
        }
    }

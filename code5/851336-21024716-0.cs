        Repeater1.ItemDataBound += new RepeaterItemEventHandler(Repeater1ItemDataBound);
        Repeater1.DataBind();
    }
    
    void Repeater1ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label label13 = (Label)e.Item.FindControl("Label13");
        if (label13.Text == "Parked") {
        //..... etc
    }

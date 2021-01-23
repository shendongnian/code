    protected void yourRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        MyDataBoundedObject bounded = (MyDataBoundedObject)e.Item.DataItem;
        Label lbText = (Label)e.Item.FindControl("myText");
        lbText.Text = bounded.myText;
    }

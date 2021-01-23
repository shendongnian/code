    protected void Button1_Click(object sender, EventArgs e)
    {
        myTable.Attributes.Remove("style");
        myTable.Attributes.Add("style", "tftable");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        myTable.Attributes.Remove("style");
        myTable.Attributes.Add("style", "CSSTable");
    }

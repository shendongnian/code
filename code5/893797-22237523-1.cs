    <asp:Repeater runat="server" ID="myRepeater" OnItemDataBound="myRepeater_ItemDataBound">
    protected void myRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Button button = (Button)e.Item.FindControl("Button_Join");
        button.Enabled = Session["join status"] != "False";
    }

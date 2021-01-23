    //Default.aspx
        <asp:BulletedList ID="bulletListTest" runat="Server" DisplayMode="HyperLink">              
        </asp:BulletedList> 
   
    //Default.aspx.cs
        var liItem = new ListItem("Test", "Val1"); 
        //Add class name
        liItem.Attributes.Add("class", "someClassNameHere");
        //Or add style
        liItem.Attributes.CssStyle.Add("background-color", "#CCC");
        bulletListTest.Items.Add(liItem);

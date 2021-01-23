    //Default.aspx
    <asp:RadioButtonList ID="rbListTest" runat="server">
    </asp:RadioButtonList>
    //Default.aspx.cs
        var liItem = new ListItem("Test", "Val1");       
        //Add class name to span element
        liItem.Attributes.Add("class", "spanClassNameHere");       
        rbListTest.Items.Add(liItem); 

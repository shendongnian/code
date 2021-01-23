    protected void cbAutoList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cbAutoList.Items.Count > 0)
            {
            }
            else
            {
            
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    <asp:DropDownList ID="cbAutoList" runat="server" CssClass="cbAutoList1" AutoPostBack="true" OnSelectedIndexChanged="cbAutoList_SelectedIndexChanged">
       <asp:ListItem Value="hai"></asp:ListItem>
       <asp:ListItem Value="hello"></asp:ListItem>
	</asp:DropDownList>

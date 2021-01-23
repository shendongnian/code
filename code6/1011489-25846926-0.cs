    <asp:RadioButtonList ID="sing_group" runat="server" RepeatDirection="Horizontal" 
                           AutoPostBack="true">
                            <asp:ListItem Value="0">Single</asp:ListItem>
                            <asp:ListItem Value="1">Group</asp:ListItem>
                        </asp:RadioButtonList>
    protected void sing_group_SelectedIndexChanged(object sender, EventArgs e) Handles 
       sing_group.SelectedIndexChanged
    {
        if (sing_group.SelectedValue == "0")
        {
            first_name.Enabled = true;
            last_name.Enabled = true;
            group_name.Enabled = false;
        }
        else
        {
            first_name.Enabled = false;
            last_name.Enabled = false;
            group_name.Enabled = true;
        }
    }

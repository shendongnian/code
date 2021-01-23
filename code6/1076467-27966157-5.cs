    // Front-End:
    <asp:ScriptManager ID="scmPage" runat="server" ></asp:ScriptManager>
    <asp:UpdatePanel ID="updDemo" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="plhControl" runat="server"></asp:PlaceHolder>
            <asp:Button ID="btnCreateText" runat="server" Text="Create" OnClick="btnCreateText_Click" />
            <asp:Button ID="btnRemoveText" runat="server" Text="Remove" OnClick="btnRemoveText_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
    // Backend:
    protected void btnCreateText_Click(object sender, EventArgs e)
    {
        var text = new TextBox();
        text.ID = "txtDynamic";
        plhControl.Controls.Add(text);
        
    }
    protected void btnRemoveText_Click(object sender, EventArgs e)
    {
        var text = new TextBox();
        text.ID = "txtDynamic";
        text.Visible = false;
    }

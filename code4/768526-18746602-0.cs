    <asp:GridView ID="gridView1" runat="server" OnRowDataBound="gview_RowDataBound" OnRowCommand="gview_RowCommand" AutoGenerateColumns="False">
    <Columns>
    <asp:TemplateField HeaderText="Active Status">
    <ItemTemplate>
    <asp:Label ID="Active" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
    <asp:Button runat="server" ID="buttonChangeActiveStatus" CommandName="<%# Eval("IsActive") %>" CommandArgument="<%# Eval("IsActive") %>" onclick="buttonChangeActiveStatus_Click" text=""/>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
    protected void gview_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType== DataControlRowType.DataRow)
    {
    Button btnnew = (button) e.Row.FindControl("buttonChangeActiveStatus");
    Label  lblactive = (Label) e.Row.FindControl("Active");
    btnnew.Text = Label.Text;
    }
    }

    <asp:GridView ID="GridView1" runat="server">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="BtnGetId" runat="server" Text="Show" CommandArgument='<%#Eval("ID")%>' CommandName="btnClick" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
----------------------------------------------------------------------------
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "btnClick")
        {
           int ID = Convert.toInt32(e.CommandArgument);
        }
    }

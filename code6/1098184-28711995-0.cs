    <asp:GridView AutoGenerateColumns="false" runat="server" ID="grdCustomPagging" OnRowCommand="grdCustomPagging_RowCommand">
       <Columns>
           <asp:BoundField DataField="RowNumber" HeaderText="RowNumber" />
           <asp:BoundField DataField="DealId" HeaderText="DealID" />
           <asp:BoundField DataField="Dealtitle" HeaderText="DealTitle" />
           <asp:TemplateField HeaderText="View">
            <ItemTemplate>
           <asp:LinkButton runat="server" ID="lnkView" CommandArgument='<%#Eval("DealId") %>'
             CommandName="VIEW">View Deal</asp:LinkButton>
             </ItemTemplate>
           </asp:TemplateField>
       </Columns>
    </asp:GridView>
    
    protected void grdCustomPagging_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VIEW")
        {
            LinkButton lnkView = (LinkButton)e.CommandSource;
            string dealId = lnkView.CommandArgument;
        }
    }

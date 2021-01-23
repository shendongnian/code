    <asp:GridView AutoGenerateColumns="false" runat="server" ID="grdCustomPagging">
       <Columns>
           <asp:BoundField DataField="RowNumber" HeaderText="RowNumber" />
           <asp:BoundField DataField="DealId" HeaderText="DealID" />
           <asp:BoundField DataField="Dealtitle" HeaderText="DealTitle" />
           <asp:TemplateField HeaderText="View">
            <ItemTemplate>
           <asp:LinkButton runat="server" ID="lnkView" OnClick="lnkView_Click">View Deal</asp:LinkButton>
             </ItemTemplate>
           </asp:TemplateField>
       </Columns>
    </asp:GridView>
    
    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        string rowNumber = grdrow.Cells[0].Text;
        string dealId = grdrow.Cells[1].Text;
        string dealTitle = grdrow.Cells[2].Text;
    }

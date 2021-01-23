     a TextBox into a GridView
    <asp:GridView ID="mygrid" runat="server">
     <Columns>
      <asp:TemplateField meta:resourcekey="TemplateFieldResource4">
       <ItemTemplate>
        <asp:TextBox ID="mytextBoxID" runat="server" Text="0,00" Enabled="false" />
       </ItemTemplate>
       <HeaderStyle Width="10%" HorizontalAlign="Right"/>
       <ItemStyle HorizontalAlign="Right" />
      </asp:TemplateField>
      </Columns>
    </asp:GridView>
    protected void any_Click(object sender, EventArgs e) {
       foreach (GridViewRow gvr in gvData.Rows)
           ((TextBox)gvr.FindControl("mytextBoxID")).Enabled = true;
     }

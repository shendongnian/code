      <asp:ListView ID="lvDetNews" runat="server" DataSourceID="sdsBerita"   OnItemDataBound="lvDetNews_ItemDataBound">
        <ItemTemplate>
            <asp:HiddenField ID="HFcari" runat="server" Value='<%# Eval("judul_berita") %>' />
            <h2><%# Eval("judul_berita") %></a></h2>            
        </ItemTemplate>
    </asp:ListView>
    protected void lvDetNews_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
             HiddenField tt = (HiddenField)e.Item.FindControl("HFcari");
              txtTitle.Value = "tess" + tt.Value;
        }
    }
       

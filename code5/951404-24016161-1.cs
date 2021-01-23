    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                         <HeaderTemplate>
                                             <tr class="">
                                             <asp:Repeater ID="Header1" runat="server">
                                                 <ItemTemplate> 
                                                     <th align="left"> <%# Container.DataItem %></th>
                                                 </ItemTemplate>
                                             </asp:Repeater>  
                                                 </tr>                                            
                                         </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="">
                                                <asp:Repeater ID="Item1" runat="server">
                                                 <ItemTemplate> 
                                                      <td><%# Container.DataItem %></td>
                                                 </ItemTemplate>
                                                </asp:Repeater>
                                                    </tr>
                                            </ItemTemplate>
                                     </asp:Repeater>
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e) 
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Repeater headerRepeater = e.Item.FindControl("Header1") as Repeater;
                headerRepeater.DataSource = dt.Columns;
                headerRepeater.DataBind();
            }
           if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater columnRepeater = e.Item.FindControl("Item1") as Repeater;
                var row = e.Item.DataItem as System.Data.DataRowView;
                columnRepeater.DataSource = row.Row.ItemArray;
                columnRepeater.DataBind();
            }
        }

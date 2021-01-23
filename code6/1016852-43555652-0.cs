        <asp:GridView ID="grdTaskDataCat1" OnRowCommand="grdTaskDataCat1_RowCommand" OnSorting="grdTaskDataCat1_Sorting" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AllowSorting="true" Width="100%" DataKeyNames="ID" runat="server" OnRowDataBound="grdTaskDataCat1_RowDataBound">
        <Columns>                                                            <asp:TemplateField HeaderText="Sr No" Visible="false">                                                      <ItemTemplate>                                                               <asp:TextBox ID="txtId" Visible="false" ReadOnly Style="width: 30%" Text='<%# Bind("ID")%>' runat="server"></asp:TextBox>                                                  </ItemTemplate>                                                          </asp:TemplateField>
        
        </Columns> 
        </asp:GridView>  
    
    **On ROW data bound of the gridview**
    protected void grdTaskDataCat1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
    TextBox txt = (TextBox)e.Row.FindControl("txtTaskName");
                   
                    if (txt.Text != "")
                    {
                        txt.Attributes.Add("readonly", "readonly");
                       
                    }
    }
    }

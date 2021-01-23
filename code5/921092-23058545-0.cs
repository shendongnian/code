        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="userId"
            OnRowCommand="GridView2_RowCommand" OnRowEditing="GridView2_RowEditing" OnRowUpdated="GridView2_RowUpdated" OnRowUpdating="GridView2_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="Username">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("username") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="password" HeaderText="password"
                    SortExpression="password" />
                <asp:BoundField DataField="utype" HeaderText="utype" SortExpression="utype" />
                <asp:BoundField DataField="ptype" HeaderText="ptype" SortExpression="ptype" />
               
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("messgae") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                     <EditItemTemplate>
                            <asp:TextBox ID="txtMsg" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" />
                    </ItemTemplate>
                  
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

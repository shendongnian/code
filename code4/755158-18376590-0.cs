     <asp:ListBox ID="ListBox1" runat="server">
                    <asp:ListItem>Manager1</asp:ListItem>
                    <asp:ListItem>Manager2</asp:ListItem>
                    <asp:ListItem>Manager3</asp:ListItem>
                    <asp:ListItem>Manager4</asp:ListItem>
                </asp:ListBox>
                <asp:GridView ID="UserAllocationGrid" runat="server"
                    AutoGenerateColumns="False">
                <Columns>
        
                    <asp:BoundField DataField="Manager" HeaderText="Manager"
                        SortExpression="managers" />
                        <asp:TemplateField HeaderText="Allocation Percentage">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"
                                Text= '<%# Bind("AllocationPercentage") %>' BorderStyle="None"></asp:TextBox>
                        </ItemTemplate>
                        </asp:TemplateField>
        
                </Columns>
                </asp:GridView>
        

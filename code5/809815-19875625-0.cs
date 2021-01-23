    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="details" HeaderText="details" 
                        SortExpression="details" />
                    <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="OK" />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:connApps %>" 
                SelectCommand="SELECT [name], [details], [age] FROM [tblA]">
            </asp:SqlDataSource>
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>

    <asp:GridView runat="server" ID="gridMe" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnName" Text="Hi" Visible='<%# DataBinder.Eval(Container.DataItem, "Name").ToString() == "Bob" %>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

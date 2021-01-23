    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="false">
        <Columns>
            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="Link" runat="server" Text="click" OnClick="link_Click"/>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="field1" HeaderText="My Column 1" />
            <asp:BoundField DataField="field2" HeaderText="My Column 2" />
         </Columns>
    </asp:GridView>

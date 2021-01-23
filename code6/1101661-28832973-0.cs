    <asp:GridView ID="ImagesGrid" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Sl No">
                <ItemTemplate><%# Container.DisplayIndex + 1 %></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:TextBox ID="txtTitle" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:TextBox ID="txtDescription" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="File">
                <ItemTemplate>
                    <asp:FileUpload ID="flUpload" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="SaveButton" Text="Save" runat="server" OnClick="SaveButton_Click"/>

    <asp:GridView ID="gdv" runat="server" 
                  OnRowDataBound="gdv_RowDataBound" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="RMAStatus" HeaderText="Original RMA Status" />
            <asp:TemplateField HeaderText="Adjusted RMA Status">
                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="New Status">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStatus" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" />
        </Columns>
    </asp:GridView>

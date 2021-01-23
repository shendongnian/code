     <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
           
            <asp:TemplateField HeaderText="Static Col 1"></asp:TemplateField>
            <asp:TemplateField HeaderText="Static Col 2" >
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnTest" Text="Hide Me"/>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
    </asp:GridView>

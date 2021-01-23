    <asp:GridView runat="server" ID="gridView" OnRowDataBound="OnGridRowDataBound">
        <Columns>
            ...
            <TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="linkButton" Click+="OnDeleteButtonClick"/>
                </ItemTemplate>
            </TemplateField>
        <Columns>
    </asp:GridView>

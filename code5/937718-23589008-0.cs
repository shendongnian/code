     <telerik:RadGrid ID="RadGrid1" DataSourceID="SqlDataSource1" AllowMultiRowSelection="true"
        runat="server" AllowSorting="True" GridLines="None" OnPreRender="RadGrid1_PreRender">
        <MasterTableView>
            <Columns>
                <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn">
                </telerik:GridClientSelectColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings EnableRowHoverStyle="true">
            <Selecting AllowRowSelect="True"></Selecting>
            <ClientEvents OnRowMouseOver="RowMouseOver" />
        </ClientSettings>
    </telerik:RadGrid>

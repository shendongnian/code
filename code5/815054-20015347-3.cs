    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script>
            function CellSelected(sender, args) {
                // I have used ColumnUniuqName 
                var row = sender.get_masterTableView().get_dataItems()[args._itemIndexHierarchical];
                var id = row.get_cell("ID").innerHTML;
                var Name = row.get_cell("Name").innerHTML;
                var Contact = row.get_cell("Contact").innerHTML;
    
                if (parseInt(id) == 3) {
                    alert("Name:-" + Name + ",Contact:-" + Contact);
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" OnNeedDataSource="RadGrid1_NeedDataSource">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="Name" UniqueName="Name" HeaderText="Name">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ID" UniqueName="ID" HeaderText="ID">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Contact" UniqueName="Contact" HeaderText="Contact">
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings>
            <Selecting CellSelectionMode="Column" />
            <ClientEvents OnCellSelected="CellSelected" />
        </ClientSettings>
    </telerik:RadGrid>

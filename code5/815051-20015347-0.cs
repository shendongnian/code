    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script>
            function RowClick(sender, args) {
                // I have used ColumnUniuqName 
                var id = args.get_item().get_cell("ID").innerHTML;
                var Name = args.get_item().get_cell("Name").innerHTML;
                var Contact = args.get_item().get_cell("Contact").innerHTML;
    
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
            <ClientEvents OnRowClick="RowClick" />
        </ClientSettings>
    </telerik:RadGrid>

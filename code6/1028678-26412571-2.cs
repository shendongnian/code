    <telerik:RadGrid ID="RG_POI" ... OnSelectedIndexChanged="rgTest_SelectedIndexChanged">
        <ClientSettings ... >
            <ClientEvents OnGridCreated="gridCreated" OnRowSelected="gridSelected" />
        </ClientSettings>
        <MasterTableView ... >
            <Columns>
                <telerik:GridEditCommandColumn UniqueName="Edit" />
                ...

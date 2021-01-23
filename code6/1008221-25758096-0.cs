    <DataGrid Name="lvpayslip">
        <DataGrid.Columns>
            <DataGridCheckBoxColumn Binding="{Binding IsSelected, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=DataGridRow}}">
                <DataGridCheckBoxColumn.Header>
                    <CheckBox Checked="CheckBox_Checked" Unchecked="CheckBox_Unchecked"/>
                </DataGridCheckBoxColumn.Header>
            </DataGridCheckBoxColumn>
        </DataGrid.Columns>
    </DataGrid>

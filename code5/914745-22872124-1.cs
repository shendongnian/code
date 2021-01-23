        <DataGrid ItemsSource="{Binding MyItems}" AutoGenerateColumns="False" >
            <DataGrid.Columns>
                <DataGridComboBoxColumn Header="Status" ItemsSource="{Binding Source={StaticResource myEnum}}">
                    <DataGridComboBoxColumn.SelectedItemBinding>
                        <Binding Converter="{StaticResource BoolToStatusConverter}" Path="Start">
                        </Binding>
                    </DataGridComboBoxColumn.SelectedItemBinding>
                </DataGridComboBoxColumn>
            </DataGrid.Columns>
        </DataGrid>

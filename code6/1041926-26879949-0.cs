    <DataGrid Name="datagridIpTable"  ItemsSource="{Binding SystemInformation, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" SelectedItem="{Binding SelectedSystemInformation}" AutoGenerateColumns="false" >
                    <DataGrid.Columns >
                        <DataGridTextColumn Binding="{Binding Sno}"  Header="S.No" MinWidth="50" />
                        <DataGridTextColumn Binding="{Binding strSystemName}" Header="IP Address" MinWidth="240" />
                        <DataGridTextColumn Binding="{Binding strStatus}" Header="Status" MinWidth="140" />
                    </DataGrid.Columns>
                </DataGrid>

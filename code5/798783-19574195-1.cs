        <DataGrid ItemsSource="{Binding Employees}">
            <DataGrid.Columns>
                <DataGridTextColumn Header="First Name" Binding="{Binding FirstName}"/>
                <DataGridTextColumn Header="Last Name" Binding="{Binding LastName}"/>
                <DataGridTextColumn Header="Gender" Binding="{Binding Gender}"/>
                <DataGridTextColumn Header="Last computer used" Binding="{Binding LastComputerUsed}"/>
                <DataGridTextColumn Header="Last connection date" Binding="{Binding LastConnectionDate}"/>
            </DataGrid.Columns>
            <DataGrid.RowDetailsTemplate>
                <DataTemplate>
                    <DataGrid ItemsSource="{Binding ComputerIDs}">
                        <DataGrid.Columns>
                            <DataGridTextColumn Header="Computer ID" Binding="{Binding ID}"/>
                            <DataGridTemplateColumn>
                                <DataGridTemplateColumn.CellTemplate>
                                    <DataTemplate>
                                        <ListView ItemsSource="{Binding ConnectionDates}"/>
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellTemplate>
                            </DataGridTemplateColumn>
                        </DataGrid.Columns>
                    </DataGrid>
                </DataTemplate>
            </DataGrid.RowDetailsTemplate>
        </DataGrid>

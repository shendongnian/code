        <DataGrid ItemsSource="{Binding Values}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="Values">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <TextBox Text="{Binding MyProperty1}"/>
                                <TextBox Text="{Binding MyProperty2}"/>
                                <TextBox Text="{Binding MyProperty3}"/>
                            </StackPanel>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>

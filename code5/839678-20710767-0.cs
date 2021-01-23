    <DataGrid.Resources>
       <namespace:MyConverter x:Key="MyConverter"/>
    </DataGrid.Resources>
    .....
    <DataGridTextColumn Header="Right"
                        Binding="{Binding SelectedColumn, Mode=OneWay, 
                                          UpdateSourceTrigger=PropertyChanged,
                                          Converter={StaticResource MyConverter}}"/>

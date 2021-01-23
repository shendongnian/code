    <DataGrid ItemsSource="{Binding Lst, UpdateSourceTrigger=PropertyChanged}"
              x:Name="dataGrid">
       <DataGrid.Resources>
           <ContextMenu x:Key="DataGridColumnHeaderContextMenu">
             <MenuItem Header="{StaticResource General}">
                <CheckBox Content="Testentry Header"
                          IsChecked="{Binding DataContext.TestCheck,
                                              Source={x:Reference dataGrid}}"/>
    ....
    </DataGrid>

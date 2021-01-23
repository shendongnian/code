    <DataGrid x:Name="TheGrid" CanUserAddRows="True" 
              ContextMenuOpening="TheGrid_ContextMenuOpening">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Number" Binding="{Binding}"/>
        </DataGrid.Columns>
        <DataGrid.InputBindings>
            <KeyBinding Key="A" Command="{x:Static ApplicationCommands.New}"/>
        </DataGrid.InputBindings>
        <DataGrid.CommandBindings>                
            <CommandBinding Command="{x:Static ApplicationCommands.Paste}" 
                            CanExecute="CanPaste" Executed="Paste"/>
            <CommandBinding Command="{x:Static ApplicationCommands.Copy}" 
                            CanExecute="CanCopy" Executed="Copy"/>
            <CommandBinding Command="{x:Static ApplicationCommands.New}" 
                            CanExecute="CanAddNew" Executed="AddNew"/>
        </DataGrid.CommandBindings>
        <DataGrid.ContextMenu>
            <ContextMenu>                   
                <MenuItem Command="{x:Static ApplicationCommands.Copy}" Header="Copy"/>
                <MenuItem Command="{x:Static ApplicationCommands.Paste}" Header="Paste"/>
                <MenuItem Command="{x:Static ApplicationCommands.New}" Header="New row"/>
            </ContextMenu>
        </DataGrid.ContextMenu>
    </DataGrid>

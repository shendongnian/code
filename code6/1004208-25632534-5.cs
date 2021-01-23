    <DataGrid.Resources>
        <myConverters:OneReturnsTrueConverter x:Key="OneReturnsTrueConverter"/>
        <ContextMenu  x:Key="DataRowContextMenu">
            <MenuItem x:Name="RowContMenuProp"  Header="Properties"
                      DataContext="{Binding Parent.PlacementTarget.Tag , RelativeSource={RelativeSource Self}}"
                      IsEnabled="{Binding Path=SelectedItems.Count, Converter={StaticResource OneReturnsTrueConverter}}" />
        </ContextMenu>
    </DataGrid.Resources>

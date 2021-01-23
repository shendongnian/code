    <ContextMenu DataContext="{Binding PlacementTarget, RelativeSource={RelativeSource Self}}" >
        <MenuItem Header="Add" Click="addTest"/>
        <MenuItem Header="Remove" Click="removeTest"
                  IsEnabled="{Binding Mode=OneWay,
                                      Path=SelectedItem, Converter={StaticResource ObjectToBool}}"/>
    </ContextMenu>

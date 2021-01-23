    <StackPanel x:Key="ConfigurationListItem" x:Shared="False" Tag="{Binding ElementName=UserControl}">
            <StackPanel Orientation="Horizontal">
                <Button>
                    <Button.InputBindings>
                        <MouseBinding Gesture="LeftDoubleClick" Command="{Binding ElementName=UserControl, Path=LaunchCommand}" CommandParameter="{Binding}" />
                        <MouseBinding Gesture="LeftClick" Command="{Binding ElementName=UserControl, Path=SelectCommand}" CommandParameter="{Binding}" />
                    </Button.InputBindings>
            </StackPanel>
            <StackPanel.ContextMenu>
                <ContextMenu DataContext="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Self}}" Tag="{Binding}">
                    <MenuItem Header="Sync Environment Dependencies" 
                            Command="{Binding Parent.PlacementTarget.Tag.SyncEnvironmentCommand, RelativeSource={RelativeSource Self}}"
                            CommandParameter="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ContextMenu}}, Path=PlacementTarget.DataContext}" />
                </ContextMenu>
            </StackPanel.ContextMenu>
        </StackPanel>

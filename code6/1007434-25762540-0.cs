    <ListBox.ItemContainerStyle>
        <Style TargetType="ListBoxItem">
            <Setter Property="ContextMenu">
                <Setter.Value>
                    <ContextMenu DataContext="{Binding RelativeSource={RelativeSource Self},Path=PlacementTarget.Tag.DataContext}">
                        <MenuItem Header="Modify"                                           
                        Command="{Binding Path=ModifyElementCommand}"
                        CommandParameter="{Binding Path=SelectedItem}"/>
                    </ContextMenu>
                </Setter.Value>
            </Setter>
            <Setter Property="Tag" Value="{Binding ElementName=AdminList}" />
        </Style>
    </ListBox.ItemContainerStyle>

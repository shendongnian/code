    <Style TargetType="{x:Type TreeViewItem}">
      <Setter Property="ContextMenu">
        <Setter.Value>
          <ContextMenu>
            <ContextMenu.DataContext>
              <local:MyViewModel/>
            </ContextMenu.DataContext>
            
            <MenuItem Command="{Binding Path=CommandPopupClick}"
                      CommandParameter="{Binding Path=SelectedItem}"
                      Header="Delete" />
            <Separator />
            <MenuItem Command="{Binding Path=CommandPopupClick}"
                      CommandParameter="{Binding Path=SelectedItem}"
                      Header="Properties" />
          </ContextMenu>
        </Setter.Value>
      </Setter>
    </Style>

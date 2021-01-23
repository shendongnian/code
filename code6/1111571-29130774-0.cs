    <ContextMenu ItemsSource="{Binding TestItems}">
       <ContextMenu.ItemContainerStyle>
          <Style TargetType="{x:Type MenuItem}">
             <Setter Property="IsChecked" Value="{Binding IsSelected}"/>
             <Setter Property="Header" Value="{Binding Header}"/>
          </Style>
       </ContextMenu.ItemContainerStyle>
    </ContextMenu>

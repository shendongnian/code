    <ContextMenu ItemsSource="{Binding TestItems}">
       <ContextMenu.ItemTemplate>
          <DataTemplate>
             <TextBlock Text="{Binding Header}"/>
          </DataTemplate>
       </ContextMenu.ItemTemplate>
       <ContextMenu.ItemContainerStyle>
          <Style TargetType="{x:Type MenuItem}">
             <Setter Property="IsChecked" Value="{Binding IsSelected}"/>
          </Style>
       </ContextMenu.ItemContainerStyle>
    </ContextMenu>

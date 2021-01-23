    <Window.Resources>
        <!--Menu template-->
        <HierarchicalDataTemplate DataType="{x:Type viewModels:MenuItemViewModel}"
                                  ItemsSource="{Binding Path=MenuItems}">
            <HierarchicalDataTemplate.ItemContainerStyle>
                <Style TargetType="MenuItem">
                    <Setter Property="Command"
                            Value="{Binding MenuCommand}"/>
                    <Setter Property="CommandParameter" 
                            Value="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type Window}}}"/>
                    <!-- No longer needed. By default menu items become disabled when its command cannot be executed (CanExecute = false).
                    <Setter Property="IsEnabled"
                            Value="{Binding IsEnabled}"/>-->
                </Style>
            </HierarchicalDataTemplate.ItemContainerStyle>
            <StackPanel Orientation="Horizontal">
                <Image Source="{Binding MenuIcon}" />
                <TextBlock Text="{Binding MenuText}" />
            </StackPanel>
        </HierarchicalDataTemplate>
    </Window.Resources>

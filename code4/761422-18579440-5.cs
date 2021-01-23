    <Window
        xmlns:v="clr-namespace:WpfApplication.Views"
        xmlns:vm="clr-namespace:WpfApplication.ViewModels">
        <Window.Resources>
            <DataTemplate DataType="{x:Type TypeName=vm:TextColumnViewModel}">
                <v:TextColumnView/>
            </DataTemplate>
        </Window.Resources>
        <ItemsControl
            ItemsSource="{Binding Columns}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel Orientation="Horizontal"/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <ContentControl Content="{Binding}"/>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Window>

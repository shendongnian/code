        <TabControl ItemsSource="{Binding Channels}" >
            <TabControl.Resources>
                <Style TargetType="TabItem">
                    <Setter Property="Header" Value="{Binding Name}" />
                </Style>
            </TabControl.Resources>
            <TabControl.ContentTemplate>
                <DataTemplate>
                    <ListBox ItemsSource="{Binding Log}"/>
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>

    <TabControl x:Name="_tabControl" ItemsSource="{Binding GameModels}">
        <TabControl.ItemContainerStyle>
            <Style TargetType="TabItem">
                <Setter Property="Header" Value="{Binding GameTitle}"/>
                <Setter Property="Content" Value="{Binding GameContent}"/>
            </Style>
        </TabControl.ItemContainerStyle>
    </TabControl>

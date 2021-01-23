     <TabControl ItemsSource="{Binding MyTabContent}">
        <TabControl.ItemTemplate>
            <!-- this is the header template-->
            <DataTemplate>
                <TextBlock Text="{Binding HeaderText}" />
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <ContentPresenter Content="{Binding}"/>
        </TabControl.ContentTemplate>
    </TabControl>

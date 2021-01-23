    <TabControl ItemsSource="{Binding ActiveRooms}">
      <TabControl.ItemTemplate>
        <DataTemplate>
            <TextBlock Text="{Binding Name}"/>
        </DataTemplate>
      </TabControl.ItemTemplate>
      <TabControl.ContentTemplate>
        <DataTemplate>
           ... (All your chat room stuff)
        </DataTemplate>
      </TabControl.ContentTemplate>
    </TabControl>

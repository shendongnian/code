    <TabControl ItemsSource="{Binding Workspaces}"
            SelectedItem="{Binding SelectedTab, Mode=TwoWay}"
            Margin="3"
            DockPanel.Dock="Top">
      <TabControl.ItemTemplate>
           <DataTemplate>
              <Label Content="{Binding DisplayName}" />
           </DataTemplate>
      </TabControl.ItemTemplate>
    </TabControl>

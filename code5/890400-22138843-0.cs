     <TabControl ItemsSource="{Binding Items}" SelectionChanged="TabControl_SelectionChanged_1">
                    <TabControl.ItemTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Header}"/>
                        </DataTemplate>
                    </TabControl.ItemTemplate>
                    <TabControl.ContentTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Content}"/>
                        </DataTemplate>
                    </TabControl.ContentTemplate>
                </TabControl>

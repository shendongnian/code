    <TabControl>
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding tabName}"/>
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate>
                <ItemsControl ItemsSource="{Binding ls}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <StackPanel>
                                <TextBlock Text="{Binding Path=Id, StringFormat='{}Id: {0}'}"/>
                                <TextBlock Text="{Binding Path=Name, StringFormat='{}Name: {0}'}"/>
                                <TextBlock Text="{Binding Path=Location, StringFormat='{}Location: {0}'}"/>
                            </StackPanel>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>

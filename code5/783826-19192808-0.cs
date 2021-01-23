    <ListView ItemsSource="{Binding VMOrder.AvailableOrders}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <Expander Content="{Binding}">
                    <Expander.HeaderTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <TextBlock Text="Order " />
                                <TextBlock Text="{Binding DataContext.Id, RelativeSource={RelativeSource FindAncestor, AncestorType=Expander}}" />
                            </StackPanel>
                        </DataTemplate>
                    </Expander.HeaderTemplate>
                    <Expander.ContentTemplate>
                        <DataTemplate>
                            <ItemsControl ItemsSource="{Binding Items}">
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate>
                                        <Expander Content="{Binding}">
                                            <Expander.HeaderTemplate>
                                                <DataTemplate>
                                                    <TextBlock Text="{Binding DataContext.Material.Name, RelativeSource={RelativeSource FindAncestor, AncestorType=Expander}}" />
                                                </DataTemplate>
                                            </Expander.HeaderTemplate>
                                            <Expander.ContentTemplate>
                                                <DataTemplate>
                                                    <TextBlock Text="{Binding DataContext.Material.Description, RelativeSource={RelativeSource FindAncestor, AncestorType=Expander}}" />
                                                </DataTemplate>
                                            </Expander.ContentTemplate>
                                        </Expander>
                                    </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                        </DataTemplate>
                    </Expander.ContentTemplate>
                </Expander>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>

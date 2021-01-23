          <ItemsControl ItemsSource="{Binding Items}">
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <Expander>
                                    <Expander.HeaderTemplate>
                                        <DataTemplate>
                                            <TextBlock Text="{Binding Material.Name}" />
                                        </DataTemplate>
                                    </Expander.HeaderTemplate>
                                    <Expander.ContentTemplate>
                                        <DataTemplate>
                                            <TextBlock Text="TEST" />
                                        </DataTemplate>
                                    </Expander.ContentTemplate>
                                </Expander>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>

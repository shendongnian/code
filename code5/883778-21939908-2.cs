    <ListBox.ItemTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Vertical">
                                <TextBlock>
                                    <TextBlock.Inlines>
                                        <Run Text="order_id:" />
                                        <Run Text="{Binding order_id}" />
                                    </TextBlock.Inlines>
                                </TextBlock>
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock Text="ItemList: " />
                                    <ItemsControl ItemsSource="{Binding itemList}" />
                                </StackPanel>
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock Text="Amount: " />
                                    <ItemsControl ItemsSource="{Binding amount}" />
                                </StackPanel>
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock Text="ImageUrls: " />
                                    <ItemsControl ItemsSource="{Binding ImageUrls}" />
                                </StackPanel>
                            </StackPanel>
                        </DataTemplate>
                    </ListBox.ItemTemplate>

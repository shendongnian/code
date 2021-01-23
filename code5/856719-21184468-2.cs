                 <ListBox Grid.Row="1"
                         Grid.Column="0"
                         Margin="3"
                         ItemsSource="{Binding SelectedOrder.OrderPositions}">
                    <ListBox.ItemTemplate>
                        <DataTemplate>
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="*" />
                                    <ColumnDefinition Width="*" />
                                </Grid.ColumnDefinitions>
                                <TextBlock Grid.Column="0">
                                    <TextBlock.Text>
                                        <MultiBinding StringFormat="{}{0}x {1}">
                                            <Binding Path="Amount" />
                                            <Binding Path="Product.Label" />
                                        </MultiBinding>
                                    </TextBlock.Text>
                                </TextBlock>
                                <TextBlock Grid.Column="1">
                                    <TextBlock.Text>
                                        <MultiBinding Converter="{StaticResource PositionPriceConverter}" StringFormat="{}{0}x {1}">
                                            <Binding Path="Amount" />
                                            <Binding Path="Product.Label" />
                                        </MultiBinding>
                                    </TextBlock.Text>
                                </TextBlock>
                            </Grid>
                        </DataTemplate>
                    </ListBox.ItemTemplate>
                </ListBox>

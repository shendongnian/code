     <ListBox x:Name="AllCategoriesList" ItemsSource="{Binding categories}" Margin="10,0">
                            <ListBox.ItemTemplate>
                                <DataTemplate>
                                    <Grid>
                                        <Grid.RowDefinitions>
                                            <RowDefinition Height="50"/>
                                            <RowDefinition Height="Auto"/>
                                        </Grid.RowDefinitions>
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition Width="*"/>
                                        </Grid.ColumnDefinitions>
                                        <TextBlock Text="{Binding name}" Grid.Row="0"></TextBlock>
                                        <ListBox ItemsSource="{Binding channels}" Grid.Row="1">
                                            <ListBox.ItemTemplate>
                                                <DataTemplate>
                                                    <StackPanel>
                                                        <TextBlock Text="{Binding name}"></TextBlock>
                                                    </StackPanel>
                                                </DataTemplate>
                                            </ListBox.ItemTemplate>
                                        </ListBox>
                                    </Grid>
                                </DataTemplate>
                            </ListBox.ItemTemplate>
                        </ListBox>

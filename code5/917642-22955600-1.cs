     this.DataContext = ViewModel;
     <ListBox x:Name="HistoryListBox"  ItemsSource="{Binding Items}"  Grid.Row="1" Grid.ColumnSpan="2">
                            <ListBox.ItemTemplate>
                                <DataTemplate>
                                    <Grid>
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition Width="*"/>
                                            <ColumnDefinition Width="*"/>
                                        </Grid.ColumnDefinitions>
        
                                        <TextBlock Grid.Column="0" Text="{Binding Network}"/>
                                        <TextBlock Grid.Column="1" Text="{Binding Date}"/>
                                    </Grid>
                                </DataTemplate>
                            </ListBox.ItemTemplate>
        </ListBox>

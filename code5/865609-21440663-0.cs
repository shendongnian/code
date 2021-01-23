    <ItemsControl>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition />
                        <RowDefinition />
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>                
                    <TextBlock  Text="{Binding ArticleName}" Grid.Row="0" Grid.Column="0" />
                    <TextBlock  Text="{Binding ArticleTradeName}" Grid.Row="0" Grid.Column="1" />
                    <ListView ItemsSource="{Binding Samples}" Grid.Row="1" Grid.Column="0" Grid.ColumnSpan="3">
                        <ListView.View>
                            <GridView>
                                .
                                .
                                .
                            <GridView>
                        </ListView.View>
                    </ListView>
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>

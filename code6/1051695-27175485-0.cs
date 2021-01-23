    <PivotItem
        x:Uid="Monday"
        Margin="19,14.5,4,0"
        Header="M"
        DataContext="{Binding Monday}"
        d:DataContext="{Binding Days[0], Source={d:DesignData Source=/DataModel/DayData.json, Type=data:SampleDataSource}}"
        CommonNavigationTransitionInfo.IsStaggerElement="True">
        <Grid Margin="0,0,12,0">
            <ItemsControl Name="calendar" ItemsSource="{Binding Entries}">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="Auto" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <TextBlock Text="{Binding StartTime}" Margin="0,0,10,5"/>
                            <TextBlock Text="{Binding Title}" Grid.Column="1"/>
                        </Grid>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
        </Grid>
    </PivotItem>

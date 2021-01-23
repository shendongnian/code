     <Grid>
        <ListView 
        ItemsSource="{Binding UserRequests}"  
        SelectionMode="Single"  
        Width="Auto"   
        ScrollViewer.VerticalScrollBarVisibility="Auto" 
        ScrollViewer.HorizontalScrollBarVisibility="Hidden">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Custom Filters" Width="170">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Button Command="{Binding Command}" Content="{Binding Text}"/>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
    </Grid>

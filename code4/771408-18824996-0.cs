     <ListView ItemsSource="{Binding}">
            <ListView.View>
                <GridView >
                    <GridViewColumn Header="Name" >
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>                              
                                <StackPanel>
                                    <ScrollViewer HorizontalScrollBarVisibility="Auto"  VerticalScrollBarVisibility="Hidden">
                                        <TextBlock Text="{Binding name}"></TextBlock>
                                    </ScrollViewer>
                                </StackPanel>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Price">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <ScrollViewer HorizontalScrollBarVisibility="Auto"  VerticalScrollBarVisibility="Hidden" >
                                        <TextBlock Text="{Binding name}"></TextBlock>
                                    </ScrollViewer>
                                </StackPanel>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>           
        </ListView>

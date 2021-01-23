    <GridView ItemsSource="{Binding DeckCollection}" IsItemClickEnabled="True" Grid.Row="0">
            <GridView.ItemTemplate>
                <DataTemplate>
                    <Button>
                        <Button.Content>
                            <Grid>
                                <Image Source="{Binding ImagePath}"
                                    Stretch="None"/>
                            </Grid>
                        </Button.Content>
                    </Button>
                </DataTemplate>
            </GridView.ItemTemplate>
        </GridView>
    <!-- public property located in Deck class -->
    <Button Command="{Binding AddItemCommand}" Content="Add Item"/>

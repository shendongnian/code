    int number_of_players = 0;
    // and in target Page you retrive the information:
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        // get the number of players passed
        number_of_players = e.Parameter as int;   
    }    
    // add in the correct number of players into the observable collection
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        ObservableCollection<sample_model> my_list = new ObservableCollection<sample_model>();
        for (int i = 0; i < number_of_players; i++)
        {
            // where sample_model is a model of a player
            my_list.Add(new sample_model("player name"));
        }
        this.myListView.ItemsSource = my_list;
    }
----------
    <ListView x:Name="myListView">
        <ListView.ItemTemplate>
            <DataTemplate>
                <Border BorderThickness="1" BorderBrush="Red">
                    <TextBlock Text="{Binding PlayerName}" Width="200" Height="200"></TextBlock>
                </Border>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>

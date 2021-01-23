    public class sample_model
    {
        public sample_model(string artist, string song, string extra = "")
        {
            this.Artist = artist;
            this.Song = song;
            this.Extra = extra;
        }
        public string Artist { get; set; }
        public string Song { get; set; }
        public string Extra { get; set; }
    }
    public class sample_viewmodel  : INotifyPropertyChanged 
    {
        public sample_viewmodel()
        {
            this.DataSource = CreateData();
        }
        // implement the INotify
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        // create a static list for our demo
        private ObservableCollection<sample_model> CreateData()
        {
            ObservableCollection<sample_model> my_list = new ObservableCollection<sample_model>();
            my_list.Add(new sample_model("Faith + 1", "Body of Christ", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Christ Again", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "A Night With the Lord", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Touch Me Jesus", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "I Found Jesus (With Someone Else)", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Savior Self", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Christ What a Day", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Three Times My Savior", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Jesus Touched Me", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Lord is my Savior", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "I Wasn't Born Again Yesterday", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Pleasing Jesus", "A Track"));
            my_list.Add(new sample_model("Faith + 1", "Jesus (Looks Kinda Hot)", "A Track"));
            my_list.Add(new sample_model("Butters", "What What", "B Track"));
            return my_list;
        }
        public ObservableCollection<sample_model> DataSource { get; set; }
        sample_model _seletedItem;
        public sample_model SelectedItem
        {
            get { return _seletedItem; }
            set
            {
                _seletedItem = value;
                NotifyPropertyChanged("SelectedItem");
            }
        }
    }
----------
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="217*"/>
            <ColumnDefinition Width="300*"/>
        </Grid.ColumnDefinitions>
        <ListView x:Name="myListView" Width="200" SelectionChanged="myListView_SelectionChanged" HorizontalAlignment="Left"
                  SelectedItem="{Binding SelectedItem, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <TextBlock Text="{Binding Artist}"></TextBlock>
                        <TextBlock Text="{Binding Song}"></TextBlock>
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
        <Button x:Name="myButton" Grid.Column="1" Content="Change Selected Item" Click="myButton_Click"></Button>
    </Grid>

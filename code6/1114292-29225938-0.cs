    <ListBox     x:Name="firstList"
                 ItemsSource="{Binding MyCollection}"
                 SelectionChanged="ListBox_SelectionChanged"
                 SelectionMode="Multiple">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <CheckBox IsChecked="{Binding checked, Mode=TwoWay}"></CheckBox>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
        <ListBox x:Name="secondList" ItemsSource={Binding SecondListCollection}/>
    private ObservableCollection<abc> myCollection;
        public ObservableCollection<abc> MyCollection
        {
            get { return myCollection; }
            set { myCollection = value; }
        }
        private ObservableCollection<abc> secondListCollection;
        public ObservableCollection<abc> SecondListCollection
        {
            get { return secondListCollection; }
            set { secondListCollection = value; }
        }
        
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SecondListCollection = (ObservableCollection<abc>)firstList.SelectedItems;
        }

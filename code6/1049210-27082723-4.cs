        public MainViewModel()
        {
            Places = new ObservableCollection<Place>()
            {
                new Place() {Title = "London", Description = "London is a nice..."},
                new Place() {Title = "Dublin", Description = "Dublin is a ...."}
            };
            SelectedPlace = Places[0];
        }

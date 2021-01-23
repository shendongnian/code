        private ObservableCollection<Content> _Collection;
         public ObservableCollection<Content> Collection
         {
            get { return _Collection; }
            set { _Collection = value; NotifyPropertyChanged("Collection"); }
        }
        // Fill it like this:
          Collection = new ObservableCollection<Content>(); 
          Collection.Add(new Content("Some Stuff", null, null));
          Collection.Add(new Content("Some Stuff", null, null));
          Collection.Add(new Content("Some Stuff", null, null));
          Collection.Add(new Content("Some Stuff",
                           new List<String>() { "One", "Two" },
                           new List<String>() { "One", "Two" }));

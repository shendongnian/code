         public ObservableCollection<PunchDetailModel> PunchDetailModels
        {
          get
          {
            return _punchDetailModels;
          }
          set
          {
            Set(PunchDetailModelsPropertyName, ref _punchDetailModels, value);
             _punchDetailModels.CollectionChanged += handler;
          }
        }           
          private void handler(object sender, NotifyCollectionChangedEventArgs e)
          {
            base.RaisePropertyChanged(PunchDetailModelsPropertyName); // If you don't have a method with such signature in ObservableObject (one that takes a string and raises PropertyChanged for it) you'll have to write it.
          }

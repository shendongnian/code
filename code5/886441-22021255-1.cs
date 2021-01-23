    private void FillRadios()
        {
            _radios = new ObservableCollection<RadioViewItem>();
    
            foreach (KeyValuePair<string, RadioStatus> radio in _state.GetRadios(PlaybackType.ToDataContract()))
            {
                RadioViewItem viewItem = ViewItemCreator.CreateFrom(radio);
                _radios.Add(viewItem); // exception is thrown here
            }
        }

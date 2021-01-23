    private void SetPropertyChanged(string property)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged( this, new PropertyChangedEventArgs(property) );
        }
    }

    #region PropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    private void PCh([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

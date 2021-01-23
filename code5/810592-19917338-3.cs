    private Theme _currentTheme;
    public Theme CurrentTheme
    {
        get
        {
            return _currentTheme;
        }
    
        private set
        {
            if (value == _currentTheme) return;
            _currentTheme = value;
            NotifyPropertyChanged("CurrentTheme");
        }
    }
    private void ThemesListPicker_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ThemesListPicker.SelectedItem == null) return;
        CurrentTheme = ThemesListPicker.SelectedItem as Theme;
    }

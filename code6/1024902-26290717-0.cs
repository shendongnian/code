    Model.PropertyChanged += OnPropertyChanged;
    private void OnPropertyChanged(object s, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == Friend.FirstNamePropertyName
            || e.PropertyName == Friend.LastNamePropertyName)
        {
            RaisePropertyChanged(() => FullName);
            return;
        }
        if (e.PropertyName == Friend.DateOfBirthPropertyName)
        {
            RaisePropertyChanged(() => DateOfBirthFormatted);
        }
    };

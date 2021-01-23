    var properties = typeof(ViewModel).GetProperties(BindingFlags.Instance | BindingFlags.Public);
    foreach (var property in properties)
    {
        this.OnPropertyChanged(new PropertyChangedEventArgs(property.Name));
    }

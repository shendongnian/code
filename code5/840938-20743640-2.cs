    private void UpdateUnderlyingCollection(
        ObservableCollection<int> underlyingCollection , 
        int element, 
        bool isChecked)
    {
        if (!isChecked)
            underlyingCollection.Remove(element);
        else if(!underlyingCollection.Contains(element))
            underlyingCollection.Add(element);
    }
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // todo; weak references
        var underlyingCollection = (ObservableCollection<int>)value;
        var lookup = underlyingCollection.ToLookup(x => x);
        var presentableCollection = new ObservableCollection<Wrap>();
        foreach (var i in Enumerable.Range(0, 400))
        {
            var damnLambdaYuNoCaptureByValue = i;
            var wrap = new Wrap { IsChecked = lookup.Contains(i)};
            wrap.PropertyChanged += (sender, args) =>
                {
                    if(args.PropertyName == "IsChecked")
                        UpdateUnderlyingCollection(
                           underlyingCollection, 
                           damnLambdaYuNoCaptureByValue, 
                           wrap.IsChecked);
                };
            presentableCollection.Add(wrap);
        }
        return presentableCollection;
    }

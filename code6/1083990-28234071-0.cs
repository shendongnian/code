    ObservableCollection<object> orderTemplateList = new ObservableCollection<object>();
    private bool toFilter;
    ObservableCollection<object> OrderTemplateList
    {
        get
        {
            if (toFilter)
                return orderTemplateList.Where(c => c.Status = FilterStatus);
            else
                return orderTemplateList;
        }
    }
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        toFilter = !toFilter;
        OnPropertyChanged("OrderTemplateList");
    }

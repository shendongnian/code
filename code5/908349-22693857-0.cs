    private Boolean _IsChecked;
    //Bind this to your checkbox
    public Boolean IsChecked
    {
        get { return _IsChecked; }
        set { _IsChecked= value; OnPropertyChanged("IsChecked"); OnPropertyChanged("TextBoxVis"); }
    }
    //Bind this to your TextBox's Visibility Property
    public Visibility TextBoxVis
    {
        get { return IsChecked ? Visibility.Visible : Visibility.Collapsed; }
    }

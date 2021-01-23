    //implement INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
       
    private void RaisePropertyChange(String propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    //property for data binding
    private bool _isucstartstudyvisible = false;
    public bool IsUCStartStudyVisible
    {
       get{return _isucstartstudyvisible;}
       set{_isucstartstudyvisible=value; RaisePropertyChange("IsUCStartStudyVisible");}
    }
    //your event to change the visibility
    public void Start_Study_Click(object sender, RoutedEventArgs e)
    {
       IsUCStartStudyVisible=true;
    }

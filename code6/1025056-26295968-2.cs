    private bool _isucstartstudyvisible = false;
    public bool IsUCStartStudyVisible
    {
       get{return _isucstartstudyvisible;}
       set{_isucstartstudyvisible=value; RaisePropertyChange("IsUCStartStudyVisible");}
    }
    public void Start_Study_Click(object sender, RoutedEventArgs e)
    {
       IsUCStartStudyVisible=true;
    }

    public EfModelClass Model { get; private set; }
    private bool _isVisibleInProjectView;
    public bool IsVisibleInProjectView
    {
        get { return _isVisibleInProjectView; }
        set { _isVisibleInProjectView; OnPropertyChanged("IsVisibleInProjectView");}
    }
    private void UpdateVisibility()
    {
        IsVisibleInProjectView = 
            (!IsDeleted && IsSelectedForDisplay 
            && Milestones.Any(ms => ms.IsVisibleInProjectView));
    } 
    public bool IsDeleted 
    {
        get { return Model.IsDeleted; }
        set 
        { 
            Model.IsDeleted = value; 
            OnPropertyChanged("IsDeleted");
            UpdateVisibility(); // This will change your IsVisibleInProjectView and notify the UI
        }
    }  
    ... 

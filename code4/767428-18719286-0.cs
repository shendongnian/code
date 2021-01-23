    public ObservableCollection<string> Conditions
    {
        get { return conditions; }
        set { return contitions;
        OnPropertyChanged("SelectedCondition");
        }
    }
    public void ConfirmCondition()
    {
        if(SelectedCondition != null){
        conditions.Remove(SelectedCondition );
        }
    }

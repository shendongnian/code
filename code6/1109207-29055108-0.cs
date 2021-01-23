    private bool showFlyout;
    public bool ShowFlyout
    {
        get
        { 
            return showFlyout;
        }
        set
        {
            showFlyout = value; 
            PropertyChanged("ShowFlyout");
        }
    }
    public void btn_Add()
    {
        _income.Add(new Transaction (_labelToAdd,  10.00M, DateTime.Now));
        _labelToAdd = string.Empty;
        NotifyOfPropertyChange(() => LabelToAdd);
        ShowFlyout = false;
    }

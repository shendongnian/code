    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {
        base.OnBackKeyPress(e);
        PhoneApplicationService.Current.State["LastPage"] = this; 
    }

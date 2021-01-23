    protected override bool IsEnabledCore
    {
        get
        {
            return ( base.IsEnabledCore && _canExecute );
        }
    }

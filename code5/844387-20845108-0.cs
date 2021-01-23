    private readonly DelegateCommand<object> rbCheckedCommand;
    public ICommand RbCheckedCommand
    {
        get { return this.rbCheckedCommand; }
    }
    private void RbCheckedCommandExecute(object obj)
    {
        string rbselected = obj.ToString();
    }

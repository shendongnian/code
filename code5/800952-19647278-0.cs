    public ICommand DeleteItemCommand {
        get { return new DelegateCommand(deleteItemClicked, alwaysCanInvoke); }
    }
    
    private deleteItemClicked(object param) {
     // Business logic here to remove item based on param
    }

    private readonly ISelectListsWrapper selectLists;
    public CustomerController(ICustomerManager customerMan, ISelectListsWrapper selectLists)
    {
        cm = customerMan;
        this.selectLists = selectLists;
    }
    private void InitializeContactVM(ContactVM model)
    {
        model.Customer = cm.GetViewFindCustomerDetails((int)model.CustomerId);
        model.ContactClassificationList = AddBlankToList(this.selectLists.ContactClassifications(false)); 
        model.ContactSourceList = AddBlankToList(this.selectLists.ContactSources(false));
    }

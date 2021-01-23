    public AddEditForm(IBookRepository repository)
    {
        IsNew = true;
        ...
    }
    public bool IsNew { get; private set; }

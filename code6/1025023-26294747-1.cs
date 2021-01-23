    IMyForm
    {
    }
    IFormWithList:IMyForm
    {
        ListBox ListBox { get; set; }
    }
    IFormWithTreeView:IMyForm
    {
        TreeView TreeView { get; set; }
    }

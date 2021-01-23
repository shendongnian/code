    public ActionCommand<DragEventArgs> DropCommand { get; private set; }
    this.DropCommand = new ActionCommand<DragEventArgs>(OnDrop);
    
    private void OnDrop(DragEventArgs e)
    {
        // ...
    }

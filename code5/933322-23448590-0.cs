    public Form1()
    {
        InitializeComponent();
        theTree.AfterSelect += (sender, args) => ShowSelectedNode();
    }
    private void ShowSelectedNode() {
        var node = theTree.SelectedNode;
        var viewable = node.Tag as IViewable;
        if (viewable != null) {
            viewable.View(this);
        }
    }

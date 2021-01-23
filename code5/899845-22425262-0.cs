    public TreeWindow(TreeNode node)
    {
        InitializeComponent();
        treeView.Items.Add(ConvertToWpf(node));
    }
    
    TreeViewItem ConvertToWpf(TreeNode node)
    {
        var wpfItem = new TreeViewItem();
        wpfItem.Header = node.Text;
        foreach(var child in node.Nodes)
        {
             wpfItem.Items.Add(ConvertToWpf(child));
        }
        return wpfItem;
    }

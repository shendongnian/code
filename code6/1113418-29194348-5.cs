    protected void AddDefault(TreeNode c)
    {
        c.Children.Add(new DoubleChild { Value = 3 });
        c.Children.Add(new DoubleChild { Value = 4 });
    }
    TreeListView treeListView1;
    public Form1()
    {
        InitializeComponent();
        treeListView1 = new TreeListView();
        treeListView1.CellClick += treeListView1_CellClick;
        OLVColumn columnName = new OLVColumn();
        columnName.AspectGetter = (obj) =>
        {
            var node = obj as TreeNode;
            if (node != null)
            {
                return node.Name;
            }
            return " ";
        };
        OLVColumn columnValue = new OLVColumn("Value", "Value");
        treeListView1.Columns.Add(columnName);
        treeListView1.Columns.Add(columnValue);
        TreeNode rootContract = new TreeNode() { Name = "All Contracts" };
        Contract childContract1 = new Contract() { Name = "A", Value = 2 };
        Contract childContract2 = new Contract() { Name = "B", Value = 3 };
        AddDefault(childContract1);
        AddDefault(childContract2);
        rootContract.Children.Add(childContract1);
        rootContract.Children.Add(childContract2);
        AddDefault(rootContract);
        treeListView1.ParentGetter = (obj) =>
        {
            var child = obj as ITreeChild;
            if (child == null)
            {
                return null;
            }
            return child.Parent;
        };
        treeListView1.ChildrenGetter = (obj) =>
        {
            var child = obj as ITreeNode;
            if (child == null)
            {
                return null;
            }
            return child.Children;
        };
        treeListView1.CanExpandGetter = (obj) =>
        {
            return obj is ITreeNode && ((ITreeNode)obj).Children.Count > 0;
        };
        treeListView1.AddObject(rootContract);
        treeListView1.Dock = DockStyle.Fill;
        this.Controls.Add(treeListView1);
    }
    void treeListView1_CellClick(object sender, CellClickEventArgs e)
    {
        if (e.Model is Contract)
        {
            // you selected a contract
        }
        else
        {
            var tree = e.Model as ITreeChild;
            var parent = tree.Parent;
            if (parent is Contract)
            {
                // selected contract
            }
            else
            {
                // rootnode
            }
        }
    }

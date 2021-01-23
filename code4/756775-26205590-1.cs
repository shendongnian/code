    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode MainNode = new TreeNode("Java");
            tvwDynamic.Nodes.Add(MainNode);
            MainNode = new TreeNode("PHP");
            tvwDynamic.Nodes.Add(MainNode);           
            TreeNode node2 = new TreeNode("C#");
            TreeNode node3 = new TreeNode("VB.NET");
            TreeNode[] childNodes = new TreeNode[] {node2,node3};
            MainNode = new TreeNode("ASP.NET", childNodes);
            tvwDynamic.Nodes.Add(MainNode);
             TreeNode node4 = new TreeNode("Winforms");
            TreeNode node5 = new TreeNode("Webforms");
              TreeNode[] SubchildNodes = new TreeNode[] {node4,node5};
            MainNode =  new TreeNode("Test",SubchildNodes);
            tvwDynamic.Nodes[2].Nodes[1].Nodes.Add(MainNode);
            tvwDynamic.CheckBoxes = true;
            
        }
        private void tvwDynamic_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
            SelectParents(e.Node, e.Node.Checked);
           
        }
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
        private void SelectParents(TreeNode node, Boolean isChecked)
        {
            var parent = node.Parent;
            if (parent == null)
                return;
            if (!isChecked && HasCheckedNode(parent))
                return;
            parent.Checked = isChecked;
            SelectParents(parent, isChecked);
        }
        private bool HasCheckedNode(TreeNode node)
        {
            return node.Nodes.Cast<TreeNode>().Any(n => n.Checked);
        }
    } }

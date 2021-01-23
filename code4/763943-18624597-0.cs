    private List<TreeNode> previousNodes;
    
    public Form1()
    {
        InitializeComponent();
    
        previousNodes = new List<TreeNode>();
                
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        previousNodes.Add(treeView1.Nodes[0]);
        //Clear out nodes, add new ones
        //Compare by treeView1.Nodes[0].Text == previousNodes.Last().Text
    }

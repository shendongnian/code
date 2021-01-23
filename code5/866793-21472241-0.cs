    public partial class MainForm : Form
    {
        private List<GenericNode> nodeTree;
        public MainForm()
        {
            InitializeComponent();
            nodeTree = new List<GenericNode>();
        }
        private void testitemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenericNode node = new GenericNode();
            nodeTree.Add(node);
            node.Name = "node" + nodeTree.Count;
            node.Location = PointToClient(MousePosition);
            this.Controls.Add(node);
        }
    }

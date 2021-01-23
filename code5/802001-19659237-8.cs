    public class Program
    {
        public static IEnumerable<TreeNode> GetNodesByDepth(TreeView treeView, int depth)
        {
            var nodes = treeView.Nodes.Cast<TreeNode>();
            for (int i = 0; i < depth; i++)
                nodes = nodes.SelectMany(n => n.Nodes.Cast<TreeNode>());
            return nodes;
        }
        static void Main(string[] args)
        {
            TreeView treeView = new TreeView();
            TreeNode node1 = new TreeNode("1");
            TreeNode node2 = new TreeNode("2");
            TreeNode node3 = new TreeNode("3");
            TreeNode node4 = new TreeNode("4");
            TreeNode node5 = new TreeNode("5");
            TreeNode node6 = new TreeNode("6");
            TreeNode node7 = new TreeNode("7");
            treeView.Nodes.Add(node1);
            node1.Nodes.Add(node2);
            node1.Nodes.Add(node5);
            node2.Nodes.Add(node3);
            node2.Nodes.Add(node4);
            node5.Nodes.Add(node6);
            node5.Nodes.Add(node7);
            Console.WriteLine("Method 1:");
            var nodes = treeView.Nodes
               .Cast<TreeNode>()
               .SelectMany(n => n.Nodes.Cast<TreeNode>())
               .SelectMany(n => n.Nodes.Cast<TreeNode>());
            foreach (TreeNode node in nodes)
            {
                Console.WriteLine(node.Text);
            }
            Console.WriteLine();
            Console.WriteLine("----------------");
            Console.WriteLine("Method 2:");
            nodes = GetNodesByDepth(treeView, 2);
            foreach (TreeNode node in nodes)
            {
                Console.WriteLine(node.Text);
            }
        }
    }

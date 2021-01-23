    private TreeNode FindNode(String name, TreeNode root)
    {
        if(root.Name == name) return root;
        Stack<TreeNode> nodes = new Stack<TreeNode>();
        nodes.Push(root);
        while(nodes.Count > 0)
        {
            var node = nodes.Pop();
            foreach(TreeNode n in node.Nodes){
               if (n.Name == name) return n;
               nodes.Push(n);
            }
        }
        return null;
    }
    //Usage
    var node = FindNode(someName, treeView1.Nodes[0]);
    //if your treeView has more root nodes, you have to loop through them
    TreeNode node = null;
    foreach(TreeNode node in treeView1.Nodes){
      node = FindNode(someName, node);
      if(node != null) break;
    }

    internal class EmptyTreeNode : TreeNode { }
    
    private void PopulateSubModes(...)
    {
    	// ...
    
    	if (hasChildren) node.Nodes.Add(new EmptyTreeNode());
    			
    	// ...
    }
    
    private static void TreeView1OnBeforeExpand(object sender, TreeViewCancelEventArgs args)
    {
    	// If this isn't one of our special nodes... abort.
    	if (args.Node.Nodes.Count == 0 || !(args.Node.Nodes[0] is EmptyTreeNode))
    		return;
    
    	args.Node.Nodes.Clear();
    
    	// -- Do whatever to REALLY populate it
    	args.Node.Nodes.Add( new TreeNode( "Weeeeeeeee" ) );
    	args.Node.Nodes.Add( new TreeNode( "Hooooooah!" ) );
    }

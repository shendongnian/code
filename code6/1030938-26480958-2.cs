    // using System.Diagnostics;
    private void CreateDirs(string path, IEnumerable<TreeNode> nodes) {
    //  iterate through each node (use the variable `node`!)
    	foreach(var node in nodes) {
        //  combine the path with node.Text
            string dir = Path.Combine(path, node.Text);
        //  create the directory + debug printout
            Debug.WriteLine("CreateDirectory({0})", dir);
    		Directory.CreateDirectory(dir);
        //  recursion (create sub-dirs for all sub-nodes)
    		CreateDirs(dir, node.Nodes);
    	}
    }

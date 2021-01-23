    // Recursive Funcs need to be forward-declared
    Func<DirectoryEntry, TreeNode, TreeNode> addNodes = null;
    addNodes = (entry, node) =>
        {
            entry.Children
               .Cast<DirectoryEntry>()
               .ToList() // Needed for ForEach
               .ForEach(
                 child =>
                   node.ChildNodes.Add(
                         addNodes(child,
                        new TreeNode(child.Name.Substring(child.Name.IndexOf('=') + 1)))));
            return node;
        };
    
    OUs.Where(ou => ou.SchemaClassName.Contains("organizationalUnit"))
        .ToList()
        .ForEach(ou =>
                rootNode.ChildNodes.Add(addNodes(ou, 
                     new TreeNode(ou.Name.Substring(ou.Name.IndexOf('=') + 1)))));
    treeView1.Nodes.Add(rootNode);

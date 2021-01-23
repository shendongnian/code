    TreeNode nextNode = rootNode;
    for (int i = 0; i < test1.Count; i++) {
      newNodeParsed = new TreeNode(test1[i]);
      nextNode.Nodes.Add(newNodeParsed);
      nextNode = newNodeParsed;
    }

        ArrayList checkedNodes = new ArrayList();
        if (elementsHierTree.CheckedNodes.Count != 0)
        {
            foreach (TreeNode nodee in elementsHierTree.CheckedNodes)
            {
                if (nodee.Parent != null)
                {
                    checkedNodes.Add(nodee);
                }
            }
        }
        foreach (TreeNode chNode in checkedNodes)
        {
            chNode.Parent.ChildNodes.Remove(chNode);
        }

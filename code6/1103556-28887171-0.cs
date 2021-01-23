    void AddNodes(XElement parentElement, TreeNode parent = null)
    {
        if (null != parentElement)
        {
            Queue<XElement> queue = new Queue<XElement>(parentElement.Elements());
            while (queue.Count > 0)
            {
                TreeNode child = parent;
                XElement element = queue.Dequeue();
                if (!element.HasElements)
                {
                    if (null == parent)
                        treeView1.Nodes.Add(child = new TreeNode(element.Value));
                    else
                        parent.Nodes.Add(child = new TreeNode(element.Value));
                    child.Expand();
                    element = queue.Dequeue();
                }
                AddNodes(element, child);
            }
        }
    }
    AddNodes(XElement.Load("ProductDocument.xml"));

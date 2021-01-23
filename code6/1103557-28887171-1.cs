    void AddNodes(XElement parentElement, TreeNode parent = null)
    {
        Queue<XElement> queue = new Queue<XElement>(parentElement.Elements());
        while (queue.Count > 0)
        {
            TreeNode child = parent;
            XElement element = queue.Dequeue();
            if (!element.HasElements)
            {
                string value = element.Value;
                element = (XElement)element.NextNode;
                if (null != element && !element.HasElements)
                    value = element.Value;
    
                if (null == parent)
                    treeView1.Nodes.Add(child = new TreeNode(value));
                else
                    parent.Nodes.Add(child = new TreeNode(value));
                child.Expand();
                element = queue.Dequeue();
            }
            AddNodes(element, child);
        }
    }
    
    AddNodes(XElement.Load("ProductDocument.xml"));

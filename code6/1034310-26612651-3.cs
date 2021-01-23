    void flatNode(Queue<SBBTreeNode<string>> queue, List<SBBTreeNode<string>>flatTree)
    {
        if (queue.Count == 0) return;
        SBBTreeNode<string> node = queue.Dequeue();
        if (!node.IsHorizontal) flatTree.Add(node);
        if (node.Left != null) { queue.Enqueue(node.Left); }
        if (node.Left != null && node.Left.Right != null && node.Left.Right.IsHorizontal) 
            queue.Enqueue(node.Left.Right);
        if (node.Right != null) 
        { 
            if (node.Right.IsHorizontal) flatTree.Add(node.Right);   
            else queue.Enqueue(node.Right); 
        }
        flatNode(queue, flatTree);
    }

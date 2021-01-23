    public void LinkNodes()
    {
        var queue = new Queue<QuadNode>();
        LinkNodes(queue);
        QuadNode curr = this;
        foreach (var item in queue)
        {
            curr.next = item;
            curr = item;
        }
    }
    public void LinkNodes(Queue<QuadNode> queue)
    {
        queue.Enqueue(this);
        if (topLeft != null)
            topLeft.LinkNodes(queue);
        if (topRight != null)
            topRight.LinkNodes(queue);
        if (bottomRight != null)
            bottomRight.LinkNodes(queue);
        if (bottomLeft != null)
            bottomLeft.LinkNodes(queue);
    }

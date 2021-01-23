    public void LinkNodes()
    {
        var queue = new Queue<QuadNode>();
        LinkNodes2(queue);
        QuadNode curr = this;
        foreach (var item in queue)
        {
            curr.next2 = item;
            curr = item;
        }
    }
    public void LinkNodes2(Queue<QuadNode> queue)
    {
        queue.Enqueue(this);
        if (topLeft != null)
            topLeft.LinkNodes2(queue);
        if (topRight != null)
            topRight.LinkNodes2(queue);
        if (bottomRight != null)
            bottomRight.LinkNodes2(queue);
        if (bottomLeft != null)
            bottomLeft.LinkNodes2(queue);
    }

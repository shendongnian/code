    void ClearAllNodes(Node node)
    {
    start:
      if(node != null)
      {
        node.Value = null;
        node = node.Next;
        goto start;
      }
    }

    static void RemoveEmptyNodes(HtmlNode containerNode)
    {
      if (containerNode.Attributes.Count == 0 && !_notToRemove.Contains(containerNode.Name) && (containerNode.InnerText == null || containerNode.InnerText == string.Empty) )
      {
        containerNode.Remove();
      }
      else
      {
        for (int i = containerNode.ChildNodes.Count - 1; i >= 0; i-- )
        {
            RemoveEmptyNodes(containerNode.ChildNodes[i]);
        }
      }
    }

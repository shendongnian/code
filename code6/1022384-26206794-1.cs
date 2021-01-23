    public void FindAllPaths(Node startNode, Node endNode) {
      queue.Enqueue(new QueueItem(startNode, new List<Edge>()));
      while (queue.Count > 0) {
        var currentItem = queue.Dequeue();
        foreach (var edge in currentItem.Node.Edges) {
          if (!currentItem.Visited.Contains(edge)) {
            if (edge.TargetNode == endNode) {
              // currentItem.Visited.Count is the path length
              // currentItem.Visited.Sum(e => e.Weight) is the total weight
            } else {
              List<Edge> visited = new List<Edge>(currentItem.Edges);
              visited.Add(edge);
              queue.Enqueue(new QueueItem(edge.TargetNode, visited));
            }
          }
        }
      }
    }

    public void FindAllPaths(Node startNode, Node endNode) {
      queue.Enqueue(new QueueItem(startNode, new List<Edge>()));
      while (queue.Count > 0) {
        var currentItem = queue.Dequeue();
        foreach (var edge in currentItem.Node.Edges) {
          if (!currentItem.Visited.Contains(edge)) {
            List<Edge> visited = new List<Edge>(currentItem.Edges);
            visited.Add(edge);
            if (edge.TargetNode == endNode) {
              // visited.Count is the path length
              // visited.Sum(e => e.Weight) is the total weight
            } else {
              queue.Enqueue(new QueueItem(edge.TargetNode, visited));
            }
          }
        }
      }
    }

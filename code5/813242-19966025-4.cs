     // Assuming you have a NodeWrapper structure that wraps the Round objects
     public IList<NodeWrapper> BuildTrees(List<Round> list)
     {         
         Dictionary<Round, NodeWrapper> map = new Dictionary<Round, NodeWrapper>();
         List<NodeWrapper> roots = new List<NodeWrapper>();
         
         // order list and iterate through
         foreach(Round node in list.OrderBy(r => r.Depth))
         {
            NodeWrapper wrapper = new NodeWrapper(node);
            if(node.Depth == 0) {
                roots.Add(wrapper);                
            } else {
                var parentWrapper = map[node.Parent];
                parrentWrapper.AddChild(wrapper);
            }
            map.Add(node, wrapper);
         }
         return roots;
    }

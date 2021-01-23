    var nodeActions = from node in db.Nodes
        join action in db.SuggestedActions on node.Id equals action.NodeId into actions
        from action in actions.DefaultIfEmpty()
        select new { node, action };
    var minNodes = from nodeAction in nodeActions
        group nodeAction by nodeAction.node.Id
        into groupedActions
        select new
        {
            NodeId = groupedActions.Key,
            ActionAt = groupedActions.Min(c => c.action.ActionAt),
            Ahead = groupedActions.Min(c => c.action.Ahead)
        };
    var result = from minNode in minNodes
        join nodeAction in nodeActions on new { Id = minNode.NodeId, minNode.ActionAt, minNode.Ahead }
            equals new { nodeAction.node.Id, nodeAction.action.ActionAt, nodeAction.action.Ahead } into nodeActionJ
        from action in nodeActionJ
        select action;

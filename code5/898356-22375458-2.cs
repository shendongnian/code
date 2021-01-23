    // New list of currently highlighted nodes
    protected List<TreeNode> HighlightedNodes = new List<TreeNode>();
    protected void Trv_SelectedNodeChanged(object sender, EventArgs e)
    {
        var nodesToHighlight = FindPathToRoot(Trv.SelectedNode).ToList();
        // Un-highlight nodes (except those which should stay highlighted)
        UnHighlightNodes(HighlightedNodes.Except(nodesToHighlight));
        // Highlight nodes (except nodes already highlighted)
        HighlightNodes(nodesToHighlight.Except(HighlightedNodes));
        // Save the new list of highlighted nodes;
        HighlightedNodes = nodesToHighlight;
    }
    private static IEnumerable<TreeNode> FindPathToRoot(TreeNode node)
    {
        do
        {
            yield return node;
            node = node.Parent;
        } while (node != null);
    }
    private void UnHighlightNodes(IEnumerable<TreeNode> nodes)
    {
        foreach (var node in nodes)
        {
            // TODO: code to un-highlight nodes
        }
    }
    private void HighlightNodes(IEnumerable<TreeNode> nodes)
    {
        foreach (var node in nodes)
        {
            node.SelectAction = TreeNodeSelectAction.None;
            node.Text = "<div style=font-weight:bold>" + node.Text + "</div>";
        }
    }

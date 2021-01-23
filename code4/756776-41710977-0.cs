    public class BetterTreeView : TreeView
    {
    	/// <summary>
    	/// Whether to apply Checked property changes to child nodes.
    	/// </summary
    	public bool TickChildNodes { get; set; }
    
    	protected override void OnAfterCheck(TreeViewEventArgs e)
    	{
    		base.OnAfterCheck(e);
    
    		if (TickChildNodes)
            {
    			foreach (TreeNode node in e.Node.Nodes)
                {
    				node.Checked = e.Node.Checked; // Triggers OnAfterCheck (recursive)
    			}
    		}
    	}
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      ....
      // If this is the initial loading of the page, restore the navigation tree view state
      if (!IsPostBack)
          reloadTreeviewState();
    }
    /*
     * The Tools treeview state is stored in a cookie by the client before the user navigates
     * away from the page. It's in the form of one character per node with 'e' being expanded.
     */
    public void reloadTreeviewState()
    {
        try
        {
            HttpCookie cookie = Request.Cookies["ToolsTVExpand"];
            if (cookie != null && cookie.Value != null)
            {
                int currIdx = 0;
                foreach (TreeNode mainNode in TreeView1.Nodes)
                {
                    currIdx = setNodeStates(mainNode, cookie.Value, currIdx);
                }
            }
        }
        catch (Exception e)
        {
            // Just keep going
        }
    }
    protected int setNodeStates(TreeNode node, String stateInfo, int currIdx)
    {
        if (currIdx >= stateInfo.Length)
            throw new Exception("State info shorter than list of nodes.");
        Char state = stateInfo[currIdx];`enter code here`
        if (state == 'e')
        {
            node.Expand();
        }
        currIdx++;
        if (node.ChildNodes != null && node.ChildNodes.Count != 0)
        {
            foreach (TreeNode childNode in node.ChildNodes)
            {
                currIdx = setNodeStates(childNode, stateInfo, currIdx);
            }
        }
        return currIdx;
    }

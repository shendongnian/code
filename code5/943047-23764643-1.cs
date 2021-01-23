    public void ClearTree()
    {
        var currRoot = Root;
        ClearTreeHelper(ref currRoot);           
    }
    private void ClearTreeHelper(ref TreeNode currTreeRoot)
    {
        currTreeRoot = null;
    }

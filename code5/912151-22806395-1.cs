    private void visitAllChildren(UITestControl control, int depth)
    {
        UITestControlCollection kiddies = control.GetChildren();
    
        foreach ( UITestControl kid in kiddies )
        {
            if ( depth < maxDepth )
            {
                visitAllChildren(kid, depth + 1);
            }
        }
    }

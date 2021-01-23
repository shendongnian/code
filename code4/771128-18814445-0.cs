    private Control FindControlRecursive(Control root, string id)
    {
        if (root.ID == id)
            return root;
    
        foreach (Control control in root.Controls)
        {
            Control found = RecursiveFindControl(control, id);
            if (found != null)
                return found;
        }
    
        return null;
    }

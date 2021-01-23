    public Control MyFindControl(Control parent, string controlIdToFind)
    {
        foreach(Control c in parent.Controls)
        {
            Control found = MyFindControl(c, controlIdToFind);
            if (found != null)
            {
               return found;
            }
        }
    
        // control not found.
        return null;
    }

    public static List<T> FindControlsRecursive<T>(Control parent) 
      where T : Control
    {
        var foundControls = new List<T>();
        FindControlsRecursive(parent, foundControls);
        return foundControls;
    }
    
    public static void FindControlsRecursive<T>(Control parent, List<T> foundControls) 
      where T : Control
    {
        foreach (Control control in parent.Controls)
        {
            if (control is T)
                foundControls.Add((T) control);
            else
                FindControlsRecursive(control, foundControls);
        }
    }

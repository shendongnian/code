    /// <summary>
    /// Iterates throug all children and returns all of Type T.
    /// </summary>
    public static List<T> FindChildrenOfType<T>(Control control) where T : class
    {
        List<T> controls = new List<T>();
        foreach (Control childControl in control.Controls)
        {
            if (childControl.Controls.Count > 0)
            {
                controls.AddRange(FindChildrenOfType<T>(childControl, comp));
            }
            if (childControl is T)
            {
                controls.Add(childControl as T);
            }
        }
        return controls;
    }

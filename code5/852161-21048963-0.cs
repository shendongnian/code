    public static IEnumerable<Control> GetAncestors (Control control)
    {
        var current = control.Parent;
        while (current != null)
        {
            yield return current;
            current = current.Parent;
        }
    }

    public IEnumerable<T> ScanForControls<T>(Control parent) where T : Control
    {
        if (parent is T)
            yield return (T)parent;
        foreach (Control child in parent.Controls)
        {
            foreach (var child2 in ScanForControls<T>(child))
                yield return (T)child2;
        }
    }

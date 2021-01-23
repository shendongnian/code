    internal bool TreeContextIsRequired(DependencyObject target)
    {
        return ProtectedTreeContextIsRequired(target);
    }
    /// <summary> true if the ObjectRef really needs the tree context </summary>
    protected override bool ProtectedTreeContextIsRequired(DependencyObject target)
    {
        return  (   (_relativeSource.Mode == RelativeSourceMode.FindAncestor
            ||  (_relativeSource.Mode == RelativeSourceMode.PreviousData)));
    }

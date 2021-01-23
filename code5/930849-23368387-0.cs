    private bool HasDescendent(CustomType parent, CustomType descendent)
    {
        if(parent.Children.Contains(descendent))
            return true;
        return parent.Children.Any(child => HasDescendent(child, descendent);
    }
    private CustomType FindRoot(IEnumerable<CustomType> candidateRoots, CustomType node)
    {
        return candidateRoots.First(root => HasDescendent(root, node));
    }

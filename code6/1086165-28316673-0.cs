    public Guy Clone(Guy Original, Guy Parent = null)
    {
        Guy OriginalClone = new Guy();
        OriginalClone.parent = Parent;
        foreach (Guy Child in Guy.children)
        {
            OriginalClone.children.Add(Clone(Child,OriginalClone));
        }
        return OriginalClone;
    }

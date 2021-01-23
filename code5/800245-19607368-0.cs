    protected override Visual GetVisualChild(int index)
    {
        if (index < visuals.Count)
        {
            return visuals[index].Visual;
        }
        return base.GetVisualChild(index - visuals.Count);
    }

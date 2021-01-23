    public static List<Hierarchy> Select(List<int> selection)
    {
        var result = context.Hierarchy
            .Where(sub => sub.Children.Any(csub => selection.Contains(csub.Id)));
    }

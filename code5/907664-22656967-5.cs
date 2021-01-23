    IEnumerable<UIElement> FindByCell(Grid g, int row, int col)
    {
        foreach (UIElement item in g.Children)
        {
            if (Grid.GetColumn(item) == col && Grid.GetRow(item) == row)
                yield return item;
        }
    }

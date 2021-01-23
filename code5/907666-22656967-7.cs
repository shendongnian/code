    IEnumerable<UIElement> FindByCell(Grid g, int row, int col)
    {
        var childs = g.Children.Cast<UIElement>()
        return childs.Where(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col);
    }

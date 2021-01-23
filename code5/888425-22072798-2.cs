    public void AsociateGridsToElements()
    {
        var gridLookup = Grids.ToDictionary(grid => grid.ID);
        foreach (Element elem in Elements)
        {
            for (int i = 0; i < elem.Grids.Count; i++)
            {
                Grid fullyPopulatedGrid;
                if (gridLookup.TryGetValue(elem.Grids[i].ID, out fullyPopulatedGrid))
                {
                    elem.Grids[i] = fullyPopulatedGrid;
                }
                else
                {
                    // Unable to locate Grid Element
                }
            }
        }
    }

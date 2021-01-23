    public string[,] ToMultiArray(List<CellOffset> cells)
    {
        string[,] multiDimentional = new string[
            cells.Max(cell => cell.Column), cells.Max(cell => cell.Row)];
        cells.ForEach(cell => 
            multiDimentional[cell.Column, cell.Row] = cell.Value);
        return multiDimentional;
    }
    string[,] values = ToMultiArray(_cells);

    Excel.Range rng = (Excel.Range) this.Application.ActiveCell;
    int row = rng.Row;
    int column = rng.Column;
    
    if (row == 1 && column == 1)
    {
      // paste
    }

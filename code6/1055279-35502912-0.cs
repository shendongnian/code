    public override void CreateCellContent(C1FlexGrid grid, Border bdr, CellRange range)
        {
          //Ofcourse One should figure out first the col in which they want to       
          //add the cell
           var width = GetWidthForHyperlinkControl((string)grid[range.Row, range.Column]);
           var cell = new HyperlinkControl
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Width = width,
                    Height = 16,
                    NavigateUri = null,
                    IsTabStop = false,
                    Content = (string)grid[range.Row, range.Column]
                };
      }

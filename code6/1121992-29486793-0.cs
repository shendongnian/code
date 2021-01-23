    // member variable:
    Dictionary<int,Font> rowFont = new Dictionary<int,Font>();
    
    public void SetSelectedRowsFont(Font f) {
       // foreach selected row,
       // rowFont[row.Index] = f;
    }
    
    // ... in cell formatting:
    Font f = null;
    if (!rowFont.TryGetValue(e.RowIndex, out f))
        f = this.Font;
    e.CellStyle.Font = f;

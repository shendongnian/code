    if (weight is double)
    {
        product.Weight = ((double)((Excel.Range)sheet.Cells[row, 3]).Value).ToString();
    }
    else if (weight is string)
    {
        product.Weight = ((Excel.Range)sheet.Cells[row, 3]).Value;
    }

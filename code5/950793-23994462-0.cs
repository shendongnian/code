    if (e.Row.RowType == DataControlRowType.Footer)
    {
        double cellValue = 0;
        double sum = e.Row.Cells.Cast<TableCell>().Skip(18)
            .Where(cell => double.TryParse(cell.Text, out cellValue))
            .Sum(cell => cellValue);
    }

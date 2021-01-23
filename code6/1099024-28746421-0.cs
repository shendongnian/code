    //Formula update
    if (cloneFromCell.CellFormula != null && (cloneFromCell.CellFormula.FormulaType == null || !cloneFromCell.CellFormula.FormulaType.HasValue || cloneFromCell.CellFormula.FormulaType.Value == CellFormulaValues.Normal))
    {
        uint cloneRowIndex = OXMLTools.GetRowIndex(cloneFromCell.CellReference);
        uint offset = rowIndex - cloneRowIndex;
        exCell.CellFormula.Text = OXMLTools.GetUpdatedFormulaToNewRow(cloneFromCell.CellFormula.Text, offset);
    }
    public static string GetUpdatedFormulaToNewRow(string formula, uint offset)
    {
        return Regex.Replace(formula, @"[A-Za-z]+\d+", delegate(Match match)
        {
          //Calculate the new row for this cell in the formula by the given offset
          uint oldRow = GetRowIndex(match.Value);
          string col = GetColumnName(match.Value);
          uint newRow = oldRow + offset;
          //Create the new reference for this cell
          string newRef = col + newRow;
          return newRef;
        });
     }

    /// <summary>
    /// RadGridView cell validating.
    /// </summary>
    /// <param name="e">
    /// The e.
    /// </param>
    private void CellValidating(GridViewCellValidatingEventArgs e)
    {
      bool isValid = true;
      string validationText = "Validation failed. ";
      GridViewCell cell = e.Cell;
      switch (cell.Column.UniqueName)
      {
        case "Code":
        case "Name":
        case "County":
        case "Region":
          isValid = e.NewValue != null && !string.IsNullOrWhiteSpace(e.NewValue.ToString());
          if (!isValid)
          {
            validationText += string.Format("{0} is required.", cell.Column.UniqueName);
          }
          break;
           
          /* Continue case statements... */
      }
      if (!isValid)
      {
        MarkCell(cell, validationText);
      }
      else
      {
        RestoreCell(cell);
      }
      e.ErrorMessage = validationText;
      e.IsValid = isValid;
    }
    /// <summary>
    /// Marks the cell with a red box and tooltip of the validation text.
    /// </summary>
    /// <param name="cell">
    /// The cell.
    /// </param>
    /// <param name="validationText">
    /// The validation text.
    /// </param>
    private void MarkCell(Control cell, string validationText)
    {
      ToolTipService.SetToolTip(cell, validationText);
    }
    /// <summary>
    /// Restores the cell and removes the tooltip.
    /// </summary>
    /// <param name="cell">
    /// The cell.
    /// </param>
    private void RestoreCell(Control cell)
    {
      ToolTipService.SetToolTip(cell, null);
    }

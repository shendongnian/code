    private void CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
    {
      if (e.Column == passwordColumn)
      {
        e.RepositoryItem = plainTextPasswordTextEdit;
      }
    }

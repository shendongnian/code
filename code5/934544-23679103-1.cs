    private void myGrid_CellValidating(object sender, CellValidatingEventArgs e)
    {
        string errorText = string.Empty;
        // Are we really on a column currently?
        if (e.ColumnIndex >= 0)
        {
            if (e.Value == null)
            {
                 errorText = "No field may be empty";
            }
        }
    
        // Has an error occured? If so don't let the user out of the field until its corrected!
        if (errorText != string.Empty)
        {
            e.Cancel = true;
        }
        e.Row.ErrorText = errorText;
        e.Row.Cells[e.Column.Name].ErrorText = errorText;
    }

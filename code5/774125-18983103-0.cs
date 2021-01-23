    private void grd_TableControlCurrentCellChanged(object sender, GridTableControlEventArgs e)
    {
       GridDropDownGridListControlCellRenderer cr = 
          gcc.Renderer as GridDropDownGridListControlCellRenderer;
              if (cr != null)
              {
                  cr.TextBox.SelectionStart = cr.TextBox.TextLength;
                  cr.TextBox.SelectionLength = 0;
              }
    }

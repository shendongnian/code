    private void DataGridView_KeyUp(object sender, KeyEventArgs e)
    {
     if (e.Key == Key.C && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
     {
       DataObject d = DataGridView.GetClipboardContent();
       Clipboard.SetDataObject(d);
       e.Handled = true;
      }
    }

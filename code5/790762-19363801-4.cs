    private void DataGridView_KeyUp(object sender, KeyEventArgs e)
    {
     if (e.Key == Key.C &&
         (Keyboard.Modifiers & ModifierKeys.Control) == (ModifierKeys.Control))
     {
       DataObject d = DataGridView.GetClipboardContent();
       Clipboard.SetDataObject(d);
       e.Handled = true;
      }
    }

    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
         TextBox autoText = e.Control as TextBox;
         autoText.KeyPress += autoText_KeyPress;
    }
    
    void autoText_KeyPress(object sender, KeyPressEventArgs e)
    {
         TextBox autoText = sender as TextBox;
         if (autoText.Text.Length == 0 && e.KeyChar == (char)Keys.Back)
         {
              autoText.AutoCompleteMode = AutoCompleteMode.None;
         }
         if (autoText.Text.Length == 0 && e.KeyChar == '@')
         {
              autoText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
              autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
              var source = new AutoCompleteStringCollection();
              source.AddRange(new string[] { "MyValue" }); //values that should appear in the autocomplete
              autoText.AutoCompleteCustomSource = source;
              e.Handled = true;
         }
    }

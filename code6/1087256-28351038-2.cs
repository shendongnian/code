    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      if (e.Control is TextBox)
      {
        TextBox box = e.Control as TextBox;
        box.AutoCompleteCustomSource = new AutoCompleteStringCollection();
        box.AutoCompleteCustomSource.AddRange(new string[] { "Foo", "Bar", "Baz" });
        box.AutoCompleteMode = AutoCompleteMode.Suggest;
        box.AutoCompleteSource = AutoCompleteSource.CustomSource;
      }
    }

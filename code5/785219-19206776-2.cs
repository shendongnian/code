    foreach (MyObject item in selectedValues)
    {
      idTextBox.Text = item.Id;
      titleTextBox.Text = item.Title;
      contentTextBox.Text = item.Content;
    }

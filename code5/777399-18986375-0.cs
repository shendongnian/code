    using (RichTextBox test = new RichTextBox()) {
      for (int i = 0; i < dt.Rows.Count; i++) {
        test.SelectAll();
        test.Text = dt.Rows[i][1].ToString();
        string FILE_NAME = Path.Combine(path, dt.Rows[i][0].ToString() + ".rtf");
        test.SaveFile(FILE_NAME, RichTextBoxStreamType.RichText);
        test.Clear();
      }
    }

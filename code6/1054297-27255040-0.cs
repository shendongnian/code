    if (item.Length != 0)
    {
         if (!richTextBox.SelectedText.Contains(item))
         {
             int charStart = richTextBox.Find(item);
             richTextBox.SelectionFont = selectedFont;
             richTextBox.Select(charStart, item.Length);
         }
         else
         {
             int charStart = richTextBox.Find(item);
             charStart = richTextBox.Find(item, charStart + item.Length, RichTextBoxFinds.None);
              richTextBox.SelectionFont = selectedFont;
              richTextBox.Select(charStart, item.Length);
          }
    }

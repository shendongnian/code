            foreach (string item in selectionList)
            {
                if (item.Length != 0)
                {
                    int charStart = richTextBox.Find(item, RichTextBoxFinds.None);
                    while (charStart != -1)
                    { 
                        richTextBox.SelectionFont = selectedFont;
                        richTextBox.Select(charStart, item.Length);
                        charStart = richTextBox.Find(item, charStart + 1, RichTextBoxFinds.None);
                    }
                }
            }

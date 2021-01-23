    for (int j = 0; j < ptrsize; j++)
    {
       int value = (linenum[j]) * 10;
       string searchText = value.ToString();
       for (int i = 0; i < richTextBox.Lines.Count(); i++)
          {
             highlightLineContaining(richTextBox, i, searchText, Color.Red);
          }
    }

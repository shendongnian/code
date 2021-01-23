    doc = page.Documents.Open(System.IO.Path.Combine(Application.StartupPath, "old", fi));
    if (doc != null)
    {
         word.Font RegularFont = new word.Font() { Name = "Times New Roman", Size = 12 };
         word.Font BigFont = new word.Font() { Name = "Times New Roman", Size = 8 };
         for (int x = 1; x <= doc.Words.Count; x++)
         {
              if (doc.Words[x].Underline != word.WdUnderline.wdUnderlineNone && doc.Words[x].Underline != word.WdUnderline.wdUnderlineDouble)
                   doc.Words[x].Font = RegularFont;
               else
                    doc.Words[x].Font = BigFont;
          }
    }

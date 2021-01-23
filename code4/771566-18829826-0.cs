    t1.Cell(1,2).Range.ParagraphFormat.LineSpacing = 12; 
    t1.Cell(1, 2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
    t1.Cell(1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
    object oMissing = System.Reflection.Missing.Value;
    t1.Cell(1, 2).Range.Paragraphs.Add(ref oMissing);
    wordparagraphs = t1.Cell(1, 2).Range.Paragraphs;
        wordparagraphs[1].Range.Text = "Tester: " + ini.IniReadValue("Main", "Name");
    t1.Cell(1, 2).Range.Paragraphs.Add(ref oMissing);
        wordparagraphs[2].Range.Text = "Date: " + DateTime.Today.ToShortDateString();
    t1.Cell(1, 2).Range.Paragraphs.Add(ref oMissing);
        wordparagraphs[3].Range.Text = "Component: " + tabControl1.SelectedTab.Text;
    t1.Cell(1, 2).Range.Paragraphs.Add(ref oMissing);
        //freespace?
    t1.Cell(1, 2).Range.Paragraphs.Add(ref oMissing);
    wordparagraphs[5].Range.Italic = 1;
    wordparagraphs[5].Range.Text = "Task status:";
    
    t1.Cell(1, 2).Range.Paragraphs.Add(ref oMissing);
    wordparagraphs[6].Range.Bold = 1;
    wordparagraphs[6].Range.Italic = 0;
    if (impStatus.SelectedIndex == 0)
        wordparagraphs[6].Range.Font.ColorIndex = Word.WdColorIndex.wdGreen;
                           else 
        wordparagraphs[6].Range.Font.ColorIndex = Word.WdColorIndex.wdRed;
        wordparagraphs[6].Range.Font.Size = 18;
        wordparagraphs[6].Range.Text = impStatus.Text.ToUpper() ;

    Table t2 = doc.AddTable(2, 8);
    for (int i = 0; i < t2.RowCount; i ++)
    {
         for(int x = 0; x < t2.ColumnCount; x++)
         {
            t2.Rows[i].Cells[x].Paragraphs.First().Append("12").Color(Color.White);
         }
    }
    t2.AutoFit = AutoFit.Contents;
    doc.InsertTable(t2);

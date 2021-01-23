    Table t = document.AddTable(listItem.Length, 2);
    for (int i = 0; i <= listItem.Length; i++)
    {              
        t.Rows[i].Cells[0].Paragraphs.First().Append(listItem[i]);
    }
    document.InsertTable(t);

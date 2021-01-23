    Word.Table table = document.Tables[tableNumber];
    table.Select();
    wordApplication.Selection.Copy();
    for(int i = 0; i < tablesINeed; i++)
    {
        Word.Range rng = document.Range(document.Tables[tableNumber + i].Range.End + 1, document.Tables[tableNumber + i].Range.End + 1);
        rng.Select();
        wordApplication.Selection.Paste();
        // Modify table accordingly
    }

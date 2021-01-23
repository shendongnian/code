    Microsoft.Office.Interop.Word.Range rng = docs.Content;
    Microsoft.Office.Interop.Word.Find find = rng.Find;
    
    find.Font.Bold = 1;
    find.Format = true;
    
    List<string> bolds = new List<string>();
    while (find.Execute())
    {
        bolds.Add(rng.Text);
    }

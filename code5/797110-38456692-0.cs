    // Find text 
    Range range = doc.Content;
    range.Find.Execute(findText);
    // Define new range 
    range = doc.Range(range.End + 1, range.End + 1);
    range.Text = "new text...";

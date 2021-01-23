    private void FindAndItalicize(Microsoft.Office.Interop.Word.Application doc, object findText)
        {
            var rng = doc.Selection.Range;
            while(rng.Find.Execute(findText))
            {
                rng.Font.Italic = 1;
            }
        }

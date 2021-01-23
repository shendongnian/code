        foreach (Microsoft.Office.Interop.Word.Paragraph aPar in oDoc.Paragraphs) // loads all words in document
        {
            Microsoft.Office.Interop.Word.Range parRng = aPar.Range;
            string sText = parRng.Text.Replace("\r","");
            if (sText == txtBoxParagraph.Text )   // found the paragraph and i need the index of this paragraph
            {
                oDoc.Comments.Add(parRng, txtBoxComments.Text);   // to add the comment in document
            }
        }

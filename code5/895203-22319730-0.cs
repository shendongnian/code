    using word = Microsoft.Office.Interop.Word;    
    
    word.Document worddoc = new word.Document();
    for (int abc = 1; abc < worddoc.Sentences.Count; abc++)
          
    {
                            
    MessageBox.Show("Sentence value "+worddoc.Sentences[abc].Text.ToString());
    }

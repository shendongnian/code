    private async Task AddMarginNote(string noteText)
    {                    
        // get current cursor position
        int sPos = editor.Document.Selection.StartPosition;
        // select everything from the start of the document to the current position
        editor.Document.Selection.StartPosition = 0;
        editor.Document.Selection.EndPosition = sPos;
        
        // get selected text
        string text = "";
        editor.Document.Selection.GetText(TextGetOptions.None, out text);
        
        // set MarginHelper text to selected text
        MarginHelper.Document.SetText(TextSetOptions.None, text);
        
        // reset the editor selection 
        editor.Document.Selection.StartPosition = sPos;
        // measure height of MarginHelper 
        // (less 25 pixels, I'm not sure where this extra height is 
        // creeping in but its the only way to make this accurate)
        double mHeight = MarginHelper.ActualHeight - 25;
                    
        // add a note to MarginNotes
        TextBlock note = new TextBlock();
        note.Text = noteText;
        note.Foreground = new SolidColorBrush(Colors.White); 
        note.Margin = new Thickness { Top = mHeight }; 
        MarginNotes.Children.Add(note);        
        
        // save note to db
        // code here would store noteText along with text.Length for this document
    }
   

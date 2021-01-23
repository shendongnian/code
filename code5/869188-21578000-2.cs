    private async void LoadNote(string noteText, int chars)
    {
        // set selection 
        editor.Document.Selection.StartPosition = 0;
        editor.Document.Selection.EndPosition = chars;
        // get text
        string text = "";
        editor.Document.Selection.GetText(TextGetOptions.None, out text);
        // set MarginHelper text
        MarginHelper.Document.SetText(TextSetOptions.None, text);
        // measure height of MarginHelper
        double mheight = MarginHelper.ActualHeight - 25;
        
        // add a note to MarginNotes
        TextBlock note = new TextBlock();
        note.Text = noteText;
        note.Foreground = new SolidColorBrush(Colors.White);
        note.Margin = new Thickness { Top = mheight };
        MarginNotes.Children.Add(note);
    }

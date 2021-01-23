    private void rtbEditor_TextChanged(object sender, TextChangedEventArgs e) {
        string myText = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd).Text;
        if (myText.Length == maxlength) {
            //textboxfull
        }
        else if (myText.Length > maxlength) {
            //textbox over flow
        }
    }

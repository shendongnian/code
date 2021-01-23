    private void richtextBox1_TextChanged(object sender, TextChangedEventArgs e)
    {
    	string text = new TextRange(richtextBox1.Document.ContentStart, richtextBox1.Document.ContentEnd).Text;
    	MessageBox.Show(text);
    }

    private List<string> _history = new List<string>();
    private int _historyIndex = -1;
    
    private void TextBox_PreviewKeyUp(object sender, KeyEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        if (e.Key == Key.Return)
        {
            _history.Add(textBox.Text);
            if (_historyIndex < 0 || _historyIndex == _history.Count - 2)
            {
                _historyIndex = _history.Count - 1;
            }
    
            textBox.Text = String.Empty;
    
            return;
        }
    
        if (e.Key == Key.Up)
        {
            if (_historyIndex > 0)
            {
                _historyIndex--;
                textBox.Text = _history[_historyIndex];
            }
    
            return;
        }
    
        if (e.Key == Key.Down)
        {
            if (_historyIndex < _history.Count - 1)
            {
                _historyIndex++;
                textBox.Text = _history[_historyIndex];
            }
    
            return;
        }
    }

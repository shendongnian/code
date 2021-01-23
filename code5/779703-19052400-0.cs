    TextBox myTextBox;
    private string _text;
    public string Text
    {
        get
        {
            return _text;
        }
        set
        {
            if (_text != value)
            {
                _text = value;
                OnTextChanged();
            }
        }
    }
    private void textBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (Text != myTextBox.Text)
        {
            // the user must have edited the TextBox
            Text = myTextBox.Text;
        }
    }
    private void OnTextChanged()
    {
        if (myTextBox.Text != Text)
            myTextBox.Text = Text;
    }

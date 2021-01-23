    private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        TextBox currentContainer = ((TextBox)sender);
        int caretPosition = currentContainer.SelectionStart;
    
        currentContainer.Text = currentContainer.Text.ToUpper();
        currentContainer.SelectionStart = caretPosition++;
    }

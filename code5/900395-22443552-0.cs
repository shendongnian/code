    private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        TextBox currentContainer = ((TextBox)sender);
        int caretPosition = currentContainer.SelectionStart;
    
        ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
        currentContainer.SelectionStart = caretPosition++;
    }

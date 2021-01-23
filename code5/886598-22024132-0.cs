    private void MyTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        int myCaretIndex = MyTextBox.CaretIndex;
        char[] characters = MyTextBox.Text.ToCharArray();
        if (myCaretIndex < characters.Length)
        {
            characters[myCaretIndex] = char.Parse(e.Key.ToString());
            MyTextBox.Text = string.Join("", characters);
            MyTextBox.CaretIndex = myCaretIndex + 1;
            e.Handled = true;
        }
    }

    private string oldState;
    private void richTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if(e.KeyChar == ' ')
        {
            MessageBox.Show(FindNewWord(oldState, richTextBox.Text));
            oldState = richTextBox.Text;
        }
    }

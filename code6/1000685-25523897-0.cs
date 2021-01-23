    public delegate void updateTextBoxDelegate(string textBoxString);
    public updateTextBoxDelegate updateTextBox;
    void updateTextBox1(string message) { richTextBox2.Text = message + '\n'; }
    void UpdatetextBox(string strItem)
    {
        if (richTextBox2.InvokeRequired)
        {
            this.Invoke(this.updateTextBox, strItem);
        }
    }

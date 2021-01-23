    public void insertFont()
    {
        if (textBox1.SelectionLength > 0)
        {
            xx = textBox1.SelectedText;
            textBox1.SelectedText = textBox1.SelectedText.Replace(xx, "" + family + "\" + size + color + "a");    
        }
        else
        {
            textBox1.Paste("" + family + "\" + size + color + "a");
        }
    }

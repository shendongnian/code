    public void MBox(string msgText, string msgCaption, 
        MessageBoxButtons msgButton = MessageBoxButtons.OK, 
        MessageBoxIcon msgIcon = MessageBoxIcon.None)
    {
        MessageBox.Show(msgText, msgCaption, msgButton, msgIcon);
    }

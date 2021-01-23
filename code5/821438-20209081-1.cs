    private void btnCopy_Click(object sender, EventArgs e)
    {
    	richTextBox1.SelectAll();
    	richTextBox1.Copy();
    }
    
    private void btnPaste_Click(object sender, EventArgs e)
    {
    	richTextBox2.Paste();
    }
    
    private void btnCut_Click(object sender, EventArgs e)
    {
    	richTextBox1.SelectAll();
    	richTextBox1.Cut();
    }

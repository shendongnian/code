    private void TextBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
    	switch (e.KeyCode) {
    		case Keys.PageDown:
    			this.LVW_PGDN();
    			break;
    	}
    }
    private void LVW_PGDN()
    {
    	int top = this.ListView1.TopItem.Index;
    	int i = top;
    
    	do {
    		i++;
            if (i > this.ListView1.Items.Count - 1) {
                break;
            }
    		this.ListView1.EnsureVisible(i);
    	} while (top == this.ListView1.TopItem.Index);
    
    	this.ListView1.TopItem = this.ListView1.Items(i - 1);
    }

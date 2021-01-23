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
    	int i;
    
        for (i = top; i < this.ListView1.Items.Count; i++) {
            this.ListView1.EnsureVisible(i);
            if (top < this.ListView1.TopItem.Index) {
                break;
            }
        }
    	this.ListView1.TopItem = this.ListView1.Items(i - 1);
    }

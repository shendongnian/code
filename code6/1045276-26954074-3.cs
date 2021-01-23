    private void TextBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
    	switch (e.KeyCode) {
    		case Keys.PageDown:
    			this.ListView1.Focus();
    			SendKeys.Send("{pgdn}");
    			break;
    	}
    }
    
    private void ListView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
    	switch (e.KeyCode) {
    		case Keys.PageDown:
    			this.TextBox1.Focus();
    			break;
    	}
    }

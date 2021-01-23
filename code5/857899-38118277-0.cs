    private void Me_ToggledChanged(System.Object sender, System.EventArgs e)
    {
    
    	if (this.Parent != null) {
    
    
    		Control topParent = this;
    		int x = 0;
    		int y = 0;
    
    		while (topParent.Parent != null) {
    			x += topParent.Left;
    			y += topParent.Top;
    			topParent = topParent.Parent;
    		}
    
    		if (this.Toggled) {
    			if (!topParent.Controls.Contains(dropDownMenu)) {
    				topParent.Controls.Add(dropDownMenu);
    			}
        			
    			dropDownMenu.Location = new Point(x, y);        
    			dropDownMenu.Visible = true;
    			dropDownMenu.BringToFront();
    		} else {
    			if (topParent.Controls.Contains(dropDownMenu)) {
    				this.Parent.Controls.Remove(dropDownMenu);
    			}
    			dropDownMenu.Visible = false;
    		}
    
    	}
    }

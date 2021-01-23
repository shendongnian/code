    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
    	if (!object.ReferenceEquals(this.ActiveControl, listView1) && (e.ItemIndex != -1)) 
        {
            // ToDo offer an early exit if HideSelection is false (?)
    		if (e.Item.Selected) 
            {
    			e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), 
                                         e.Bounds);
    
    			TextRenderer.DrawText(
                          e.Graphics, " " + listView1.Items(e.ItemIndex).SubItems(e.ColumnIndex).Text, 
                          listView1.Font, e.Bounds, 
                          SystemColors.HighlightText, SystemColors.Highlight, 
                          TextFormatFlags.Left | TextFormatFlags.VerticalCenter
                          );
    
                 // default method seems off a little
    			//e.DrawText(TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
    		} else {
    			e.DrawDefault = true;
    		}
    	} else {
    		e.DrawDefault = true;
    	}
    }

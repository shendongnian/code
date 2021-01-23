    public void HookChildEvents()
    {
    	foreach (Control child in this.Controls)
    	{
    		child.MouseClick += ChildOnMouseClick;
    		child.DragEnter += ChildOnDragEnter;
    		// ... add one for each event you care for.
    	}
    }

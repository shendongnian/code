    private static ToolStripControlHost Find(Control c) {
    	var p = c.Parent;
    	while (p != null) {
    		if (p is ToolStrip)
    			break;
    		p = p.Parent;
    	}
    	if (p == null)
    		return null;
    
    	ToolStrip ts = (ToolStrip) p;
    	foreach (ToolStripItem i in ts.Items) {
    		var h = Find(i, c);
    		if (h != null)
    			return h;
    	}
    	return null;
    }
    
    private static ToolStripControlHost Find(ToolStripItem item, Control c) {
    	ToolStripControlHost result = null;
    	if (item is ToolStripControlHost) {
    		var h = (ToolStripControlHost) item;
    		if (h.Control == c) {
    			result = h;
    		}
    	}
    	else if (item is ToolStripDropDownItem) {
    		var ddm = (ToolStripDropDownItem) item;
    		foreach (ToolStripItem i in ddm.DropDown.Items) {
    			result = Find(i, c);
    			if (result != null)
    				break;
    		}
    	}
    	return result;
    }

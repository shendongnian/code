    public ObjectIdCollection SelectAllPolylineByLayer(string sLayer)
    {
        Document oDwg = Application.DocumentManager.MdiActiveDocument; 
        Editor oEd = oDwg.Editor;
    	ObjectIdCollection retVal = null;
    
    	try {
    		// Get a selection set of all possible polyline entities on the requested layer
    		PromptSelectionResult oPSR = null;
    
    		TypedValue[] tvs = new TypedValue[] {
    			new TypedValue(Convert.ToInt32(DxfCode.Operator), "<and"),
    			new TypedValue(Convert.ToInt32(DxfCode.LayerName), sLayer),
    			new TypedValue(Convert.ToInt32(DxfCode.Operator), "<or"),
    			new TypedValue(Convert.ToInt32(DxfCode.Start), "POLYLINE"),
    			new TypedValue(Convert.ToInt32(DxfCode.Start), "LWPOLYLINE"),
    			new TypedValue(Convert.ToInt32(DxfCode.Start), "POLYLINE2D"),
    			new TypedValue(Convert.ToInt32(DxfCode.Start), "POLYLINE3d"),
    			new TypedValue(Convert.ToInt32(DxfCode.Operator), "or>"),
    			new TypedValue(Convert.ToInt32(DxfCode.Operator), "and>")
    		};
    
    		SelectionFilter oSf = new SelectionFilter(tvs);
    
    		oPSR = oEd.SelectAll(oSf);
    
    		if (oPSR.Status == PromptStatus.OK) {
    			retVal = new ObjectIdCollection(oPSR.Value.GetObjectIds());
    		} else {
    			retVal = new ObjectIdCollection();
    		}
    	} catch (System.Exception ex) {
    		ReportError(ex);
    	}
    
    	return retVal;
    }

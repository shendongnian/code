    Document doc = Application.DocumentManager.MdiActiveDocument;
    Editor ed = doc.Editor;
    
    int polylineState = 1; // 0 - closed, 1 - open
    TypedValue[] vals= new TypedValue[]
    {
    	new TypedValue((int)DxfCode.Operator, "<or"),
    
    	// This catches Polyline object.
    	new TypedValue((int)DxfCode.Operator, "<and"),
    	new TypedValue((int)DxfCode.Start, "LWPOLYLINE"),
    	new TypedValue(70, polylineState),
    	new TypedValue((int)DxfCode.Operator, "and>"),
    
    	new TypedValue((int)DxfCode.Operator, "<and"),
    	new TypedValue((int)DxfCode.Start, "POLYLINE"),
    	new TypedValue((int)DxfCode.Operator, "<or"),
    	// This catches Polyline2d object.
    	new TypedValue(70, polylineState),
    	// This catches Polyline3d object.
    	new TypedValue(70, 8|polylineState),
    	new TypedValue((int)DxfCode.Operator, "or>"),
    	new TypedValue((int)DxfCode.Operator, "and>"),
    
    	new TypedValue((int)DxfCode.Operator, "or>"),
    };
    SelectionFilter filter = new SelectionFilter(vals);
    PromptSelectionResult prompt = ed.GetSelection(filter);
    
    // If the prompt status is OK, objects were selected
    if (prompt.Status == PromptStatus.OK)
    {
    	SelectionSet sset = prompt.Value;
        Application.ShowAlertDialog($"Number of objects selected: {sset.Count.ToString()}");
    }
    else
    {
    	Application.ShowAlertDialog("Number of objects selected: 0");
    }

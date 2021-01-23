    static void LoopControls(Control control)
    {
    	switch(control)
    	{
    		case Button button:
    			if(button.Name.Equals("createButton",StringComparison.Ordinal)
                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.create_on));
               
    			// other stuf if you need to...
    			break;
    		case ListView listView:
    			// other stuf if you need to...
    			break;
    		case Label label:
    			// other stuf if you need to...                  
    			break;
    		case Panel panel:
    			// other stuf if you need to...
    			break;
    		case TabControl tabcontrol:
    			// other stuf if you need to...
    			break;
    		case PropertyGrid propertyGrid:
    			// other stuf if you need to...
    			break;
    	}
    	foreach(Control child in control.Controls)
    		LoopControls(child);
    }

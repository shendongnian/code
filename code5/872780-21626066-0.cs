    public string getstring(CheckBoxList chk)
    {
    	string sFooType = "";
    	for (int i = 0; i <= chkFooTypes.Items.Count - 1; i++) {
    		if (chkFooTypes.Items(i).Selected) {
    			if (string.IsNullOrEmpty(sFooType)) {
    				sFooType = chkFooTypes.Items(i).Text;
    			} else {
    				sFooType += "," + chkFooTypes.Items(i).Text;
    			}
    		}
    	}
    	return sFooType;
    }

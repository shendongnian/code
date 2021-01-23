    foreach (void Control_loopVariable in this.Controls) {
    	Control = Control_loopVariable;
    	if ((Control) is CheckBox) {
    		((CheckBox)Control).Checked = false;
    	}
    }

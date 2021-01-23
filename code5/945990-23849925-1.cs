        foreach(RepeaterItem item in searchResultRepeater.Items){
            if(item.Controls.Count > 0 && item.Controls[0] is ITextControl ) {
	           if(((TextBox)item.Controls[0]).Text.IsNullOrEmpty()){
                    check = 1;
                    break;
           }
        }

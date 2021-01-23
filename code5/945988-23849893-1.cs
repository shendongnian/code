     foreach(RepeaterItem item in searchResultRepeater.Items){
	    for (int i = 0; i < item.Controls.Count; i++) {
	        Control ctrl = item.Controls[i];    
           	if(ctrl is TextBox){
		       TextBox tb = (TextBox) ctrl;
		       if (tb.Text != null && tb.Text.Length > 0) {
                            check = 1;
                            break;
               }
            }
       }
	   if (check == 1)
	       break;
     }

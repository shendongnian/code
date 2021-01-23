        foreach(RepeaterItem item in searchResultRepeater.Items){
           if(item is TextBox) {
                if(((TextBox)item).Text.IsNullOrEmpty()){
                    check = 1;
                    break;
           }
        }

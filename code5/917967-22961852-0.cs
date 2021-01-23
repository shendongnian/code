    var result = true;
    foreach (UITextField item in TextFieldList) {
        if (item.Text == "") {
            item.AttributedPlaceholder = 
             new NSAttributedString (item.Placeholder, foregroundColor: UIColor.Red);
            result = false;
        } 
    }
    
    return result;

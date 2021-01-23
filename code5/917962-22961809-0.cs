      public virtual Boolean ValidateTextFields(){
        
            foreach (UITextField item in TextFieldList) {
                if (item.Text == "") {
                    item.AttributedPlaceholder = new NSAttributedString (item.Placeholder, foregroundColor: UIColor.Red);
                    return false;
                } 
            }
            return true;
        }

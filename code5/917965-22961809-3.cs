      public virtual Boolean ValidateTextFields(){
            bool hasInvalidFields = false;
            foreach (UITextField item in TextFieldList) {
                if (item.Text == "") {
                    item.AttributedPlaceholder = new NSAttributedString (item.Placeholder, foregroundColor: UIColor.Red);
                    hasInvalidFields = true;
                } 
            }
            return !hasInvalidFields;
        }

    private bool ClickButton(string buttonName, Control control) {
            if (control is Button && control.Text.Contains(buttonName) {
                ((Button)control)PerformClick();
                return true;
            } 
            
            if (control.HasChildren) {
                foreach (Control childControl in control.Controls) {
                    if (ClickButton(buttonName, childControl)) {
                        return true;
                    }
                    
                }
            }
            return false;
        }

    public class AutofocusTextBox : TextBox
    {
        public AutofocusTextBox()
        {
            GotFocus += (sender, e) => SelectAll();
        }
    }

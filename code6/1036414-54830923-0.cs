        // called by ui... used to highlight a textbox on focus
        public void GotFocusMethod(object source)
        {
            var based = source as TextBox;
            based.SelectAll();
        } // close gotfocusmethod
        // called by ui... used to highlight a textbox on focus
        public void SelectivelyIgnoreMouseButton(object sender, MouseButtonEventArgs eve)
        {
            TextBox tb = (sender as TextBox);
            if (tb != null)
            {
                if (!tb.IsKeyboardFocusWithin)
                {
                    eve.Handled = true;
                    tb.Focus();
                }
            }
        } // close selectivelyignoremousebutton()

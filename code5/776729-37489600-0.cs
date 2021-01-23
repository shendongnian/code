        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();
        private Control GetFocusedControl()
        {
            Control focusedControl = null;
            // To get hold of the focused control:
            IntPtr focusedHandle = GetFocus();
            if (focusedHandle != IntPtr.Zero)
                // Note that if the focused Control is not a .Net control, then this will return null.
                focusedControl = Control.FromHandle(focusedHandle);
            return focusedControl;
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                var FocusedControl = GetFocusedControl();
                if (FocusedControl != null)
                    switch (FocusedControl.GetType().Name)
                    {
                        case "RichTextBox":
                            {
                                var RichTextBox = FocusedControl as RichTextBox;
                                RichTextBox.Paste();
                                break;
                            }
                        case "TextBox":
                            {
                                var TextBox = FocusedControl as TextBox;
                                TextBox.Paste();
                                break;
                            }
                    }
            }
        }

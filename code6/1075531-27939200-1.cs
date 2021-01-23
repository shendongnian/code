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
        private void textBox3_Leave(object sender, EventArgs e)
        {
            //Any control that is allowed to acquire focus is just added to this array.
            Control[] allowedToAcquireFocusControls = { 
                     textBox1
                };
            Control focusedControl = GetFocusedControl();
            if (!allowedToAcquireFocusControls.Contains(focusedControl))
            {
                textBox3.Focus();
            }
        }

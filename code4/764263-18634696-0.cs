    this.KeyPreview = true;
     protected override void OnKeyDown(KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                    PressedEnter();
                base.OnKeyDown(e);
            }
            private void PressedEnter()
            {
               Control ctr = GetFocusedControl();
               if (ctr != null && ctr is TextBox)
               {
                   bool res = this.SelectNextControl(ctr, true, true, true, true);
               }
            }
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
            internal static extern IntPtr GetFocus();
            private Control GetFocusedControl()
            {
                Control focusedControl = null;
                IntPtr focusedHandle = GetFocus();
                if (focusedHandle != IntPtr.Zero)
                    // if control is not a .Net control will return null
                    focusedControl = Control.FromHandle(focusedHandle);
                return focusedControl;
            }

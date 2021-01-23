    [DllImport("user32")]
    private static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);
    private void dateTimePickers_Enter(object sender, EventArgs e){
       DateTimePicker picker = sender as DateTimePicker;
       //WM_SETREDRAW = 0xb
       SendMessage(picker.Handle, 0xb, new IntPtr(0), IntPtr.Zero);//BeginUpdate()
       typeof(DateTimePicker).GetMethod("RecreateHandle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(picker, null);
       SendMessage(picker.Handle, 0xb, new IntPtr(1), IntPtr.Zero);//EndUpdate()
    }

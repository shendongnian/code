    NativeWindow nw = new System.Windows.Forms.NativeWindow();
               nw.AssignHandle(new IntPtr(wb.Parent.Hwnd));
               
    DialogResult result = MessageBox.Show(nw,"Do you want to save the " +
               "changes you made to " + wb.FullName + "?", "Blizzard Excel",
               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button1);

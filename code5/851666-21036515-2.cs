    public void AttachButtonToSkype() {
      // find skype main window (className = tSkMainForm)
      var mainHandle = NativeMethods.FindWindow("tSkMainForm", null);
      
      if (mainHandle != IntPtr.Zero) {
        // find child window to inject (className = TMyselfControl)
        var parentHandle = NativeMethods.FindWindowEx(mainHandle, IntPtr.Zero, "TMyselfControl", null);
        if (parentHandle != IntPtr.Zero)
        {          
          var button = new Button { Text = "Click Me!", Left = 150, Top = 5, Width = 75, Height = 25 };
          button.Click += (o, args) => { MessageBox.Show("You've clicked me"); };
          NativeMethods.SetParent(button.Handle, parentHandle);
        }
      }
    }

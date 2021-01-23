    private void Wheel(int ticks){
      //WM_MOUSEWHEEL = 0x20a
      Message msg = Message.Create(Handle, 0x20a, new IntPtr(-120), new IntPtr(MousePosition.X + MousePosition.Y << 16));
      for(int i = 0; i < ticks; i++)
          WndProc(ref msg);
    }
    //Use it
    Wheel(20);
    

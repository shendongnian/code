    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    public sealed class KeyboardHook : IDisposable
    {
        private int _currentId;
        private Window _window;
    
        public event EventHandler<KeyPressedEventArgs> KeyPressed;
    
        public KeyboardHook()
        {
            EventHandler<KeyPressedEventArgs> handler = null;
            this._window = new Window();
            if (handler == null)
            {
                handler = delegate (object sender, KeyPressedEventArgs args) {
                    if (this.KeyPressed != null)
                    {
                        this.KeyPressed(this, args);
                    }
                };
            }
            this._window.KeyPressed += handler;
        }
    
        public void Dispose()
        {
            for (int i = this._currentId; i > 0; i--)
            {
                UnregisterHotKey(this._window.Handle, i);
            }
            this._window.Dispose();
        }
    
        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            this._currentId++;
            if (!RegisterHotKey(this._window.Handle, this._currentId, (uint) modifier, (uint) key))
            {
                throw new InvalidOperationException("Couldn’t register the hot key.");
            }
        }
    
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    
        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x312;
    
            public event EventHandler<KeyPressedEventArgs> KeyPressed;
    
            public Window()
            {
                this.CreateHandle(new CreateParams());
            }
    
            public void Dispose()
            {
                this.DestroyHandle();
            }
    
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == WM_HOTKEY)
                {
                    Keys key = ((Keys) (((int) m.LParam) >> 0x10)) & Keys.KeyCode;
                    ModifierKeys modifier = ((ModifierKeys) ((int) m.LParam)) & ((ModifierKeys) 0xffff);
                    if (this.KeyPressed != null)
                    {
                        this.KeyPressed(this, new KeyPressedEventArgs(modifier, key));
                    }
                }
            }
        }
    }

    internal class KeyboardHook : IDisposable
    {
        private readonly KeyboardHookListener _hook = new KeyboardHookListener(new GlobalHooker());
        public KeyboardHook()
        {
            _hook.KeyDown += hook_KeyDown;
            _hook.Enabled = true;
        }
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == (Keys.Control | Keys.C)))
            {
                //your implementation
                e.SuppressKeyPress = true; //other apps won't receive the key
            }
            else if ((e.KeyCode == (Keys.Control | Keys.V)))
            {
                //your implementation
                e.SuppressKeyPress = true; //other apps won't receive the key
            }
        }
        public void Dispose()
        {
            _hook.Enabled = false;
            _hook.Dispose();
        }
    }

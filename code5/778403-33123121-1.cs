    /// <summary>
    /// Interaction logic for KeyTestWindow.xaml
    /// </summary>
    public partial class KeyTestWindow : Window
    {
        int MaxKeyCount = 3;
        List<Key> PressedKeys = new List<Key>();
        List<Key> AllowedKeys = new List<Key>();
        public KeyTestWindow()
        {
            InitializeComponent();
            tbHotkeys.Focus();
            //Init the allowed keys list
            AllowedKeys.Add(Key.LeftCtrl);
            AllowedKeys.Add(Key.A);
            AllowedKeys.Add(Key.B);
            AllowedKeys.Add(Key.LeftShift);
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Handled) return;
            //Check all previous keys to see if they are still pressed
            List<Key> KeysToRemove = new List<Key>();
            foreach (Key k in PressedKeys)
            {
                if (!Keyboard.IsKeyDown(k))
                    KeysToRemove.Add(k);
            }
            //Remove all not pressed keys
            foreach (Key k in KeysToRemove)
                PressedKeys.Remove(k);
            //Add the key if max count is not reached
            if (PressedKeys.Count < MaxKeyCount)
                //Add the key if it is part of the allowed keys
                //if (AllowedKeys.Contains(e.Key))
                if (!PressedKeys.Contains(e.Key))
                    PressedKeys.Add(e.Key);
            PrintKeys();
            e.Handled = true;
        }
        private void PrintKeys()
        {
            //Print all pressed keys
            string s = "";
            foreach (Key k in PressedKeys)
                if (IsModifierKey(k))
                    s += GetModifierKey(k) + " + ";
                else
                    s += k + " + ";
            s = s.Substring(0, s.Length - 3);
            tbHotkeys.Text = s;
        }
        private bool IsModifierKey(Key k)
        {
            if (k == Key.LeftCtrl || k == Key.RightCtrl ||
                k == Key.LeftShift || k == Key.RightShift ||
                k == Key.LeftAlt || k == Key.RightAlt ||
                k == Key.LWin || k == Key.RWin)
                return true;
            else
                return false;
        }
        private ModifierKeys GetModifierKey(Key k)
        {
            if (k == Key.LeftCtrl || k == Key.RightCtrl)
                return ModifierKeys.Control;
            if (k == Key.LeftShift || k == Key.RightShift)
                return ModifierKeys.Shift;
            if (k == Key.LeftAlt || k == Key.RightAlt)
                return ModifierKeys.Alt;
            if (k == Key.LWin || k == Key.RWin)
                return ModifierKeys.Windows;
            return ModifierKeys.None;
        }
    }

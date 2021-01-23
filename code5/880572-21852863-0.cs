    private void AssignKey(ToolStripMenuItem item, string keyName)
        {
            try
            {
                Keys key = (Keys)Enum.Parse(typeof(Keys), keyName);
                item.ShortcutKeys = key;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Unknown key " + keyName);
            }
        }

    private void UpdateRegistry()
    {
        RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows CE Services");
        if (key != null)
        {
            MessageBox.Show(String.Format("value was {0}", key.GetValue("GuestOnly")));
            key.SetValue("GuestOnly", 00000001, RegistryValueKind.DWord);
            MessageBox.Show(String.Format("value is now {0}", key.GetValue("GuestOnly")));
        }
    }

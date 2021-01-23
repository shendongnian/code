       public string GetRegistryValue()
        {
            var rk = BaseRegistryKey;
            var sk1 = rk.OpenSubKey(SubKey);
                try
                {
                    return (string)sk1.GetValue("Keyname");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "some message");
                    return null;
            }
        }

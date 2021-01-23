        private void buttonGetCursorsValue_Click(object sender, EventArgs e)
        {
            RegistryKey NewKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\\Cursors", true);
            for (int j = 0, loopTo = NewKey.ValueCount - 1; j <= loopTo; j++)
                Debug.WriteLine("j = " + j + ", " + NewKey.GetValue(NewKey.GetValueNames()[j]));
        }

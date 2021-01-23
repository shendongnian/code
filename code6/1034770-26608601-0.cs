    listView1.View = View.Details;
    listView1.Columns.Add("Key Name", 150);
    listView1.Columns.Add("Key Value", 300);
    
    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
    foreach (string keyName in key.GetValueNames())
    {
        listView1.Items.Add(
            new ListViewItem(
                new string[] { keyName, key.GetValue(keyName).ToString() }
            )
        );
    }

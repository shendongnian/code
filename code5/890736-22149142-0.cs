    Private Function listregistry(ByVal hive As Microsoft.Win32.RegistryHive, ByVal path As String)
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.RegistryKey.OpenBaseKey(hive, Microsoft.Win32.RegistryView.Default).OpenSubKey(path)
        For Each subkey In key.GetSubKeyNames
            ListBox1.Items.Add(subkey.ToString)
        Next
    End Function

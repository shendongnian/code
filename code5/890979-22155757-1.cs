    Private Sub ListRegistryKeys(ByVal RegistryHive As String, ByVal RegistryPath As String)
        Dim key As Microsoft.Win32.RegistryKey
       
        Select Case RegistryHive
            Case "HKEY_LOCAL_MACHINE" : key = My.Computer.Registry.LocalMachine.OpenSubKey(RegistryPath)
            Case "HKEY_CURRENT_USER" : key = My.Computer.Registry.CurrentUser.OpenSubKey(RegistryPath)
            Case "HKEY_CLASSES_ROOT" : key = My.Computer.Registry.ClassesRoot.OpenSubKey(RegistryPath)
            Case "HKEY_CURRENT_CONFIG" : key = My.Computer.Registry.CurrentConfig.OpenSubKey(RegistryPath)
            Case "HKEY_USERS" : key = My.Computer.Registry.Users.OpenSubKey(RegistryPath)
            Case Else
                Throw New Exception("Unknow Registry Hive.")
        End Select
        key.OpenSubKey(RegistryPath)
        For Each v In key.GetValueNames()
            Dim lvItem As ListViewItem = ListView2.Items.Add(v)
            lvItem.SubItems.Add(subKey.GetValue(v))
            lvItem.SubItems.Add(subKey.GetValueKind(v).ToString())
        Next
    End Sub

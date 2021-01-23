    Dim rkTest As RegistryKey = Registry.CurrentUser.OpenSubKey("RegistryOpenSubKeyExample")
    Console.WriteLine("There are {0} subkeys under Test9999.", _
        rkTest.SubKeyCount.ToString())
    For Each subKeyName As String In rkTest.GetSubKeyNames()
        Dim tempKey As RegistryKey = _
            rkTest.OpenSubKey(subKeyName)
        Console.WriteLine(vbCrLf & "There are {0} values for " & _
            "{1}.", tempKey.ValueCount.ToString(), tempKey.Name)
        For Each valueName As String In tempKey.GetValueNames()
            Console.WriteLine("{0,-8}: {1}", valueName, _
                tempKey.GetValue(valueName).ToString())
        Next 
    Next

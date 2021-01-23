    Public Shared Sub AssignDriveLetterToPath(ByVal DriveLetter As Char, ByVal Path As String)
        If Not ApiDefinitions.DefineDosDevice(0, DriveLetter & ":", Path) Then
            Throw New ComponentModel.Win32Exception
        End If
    End Sub
    Public Shared Sub RemoveAssignedDriveLetter(ByVal DriveLetter As Char, ByVal Path As String)
        If Not ApiDefinitions.DefineDosDevice(ApiDefinitions.DDD_EXACT_MATCH_ON_REMOVE Or ApiDefinitions.DDD_REMOVE_DEFINITION, DriveLetter & ":", Path) Then
            Throw New ComponentModel.Win32Exception
        End If
    End Sub

    Private Sub CommandButton1_Click() 'Raise Error
        On Error Resume Next
        Call Err.Raise(666, "Test", "Test")
        Unload UserForm1
    End Sub
    
    Private Sub CommandButton2_Click() 'Ignore Error
        On Error Resume Next
        Call Err.Raise(667, "Test", "Test")
        Unload UserForm1
    End Sub

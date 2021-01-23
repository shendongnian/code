        Dim result As String = Microsoft.VisualBasic.InputBox("Enter some text")
        If result.Length > 0 Then
            Debug.WriteLine("Something entered and OK Clicked")
        ElseIf result = "" Then
            Debug.WriteLine("Cancel Button Clicked OR Blank String Entered and OK Clicked")
        End If

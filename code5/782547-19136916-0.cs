    Public Function isWindowsAdministrator() As Boolean
        My.User.InitializeWithWindowsUser()
        If My.User.IsAuthenticated Then
            If My.User.IsInRole(Microsoft.VisualBasic.ApplicationServices.BuiltInRole.Administrator) Then
                Return True
            End If
        End If
        Return False
    End Function

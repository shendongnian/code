    Public SomeOtherClass
    Public Function ReadFile() As CalFileInfo
        Try
            Dim objImpersonation As New UserImpersonation()
            If (objImpersonation.ImpersonateValidUser()) Then
                'Do necessary stuff....
                objImpersonation.UndoImpersonation()
            Else
                objImpersonation.UndoImpersonation()
                Throw New Exception("User do not has enough permissions to perform the task")
            End If
        Catch ex As Exception
            ''MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        Return CalFileInformation
    End Function
    End Class

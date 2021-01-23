    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            Method1()
        Catch ex As Exception
            BSExceptionHandler.ProcessException(BSExceptionHandler.GetBSException(ex, BSExceptionHandler.GetThisMethodName))
        End Try
    End Sub
    Private Sub Method1()
        Try
            method2()
        Catch ex As Exception
            Throw BSExceptionHandler.GetBSException(ex, BSExceptionHandler.GetThisMethodName)
        End Try
    End Sub
    Private Sub method2()
        Try
            Dim x As Integer = CInt("x") 'exception thrown here.
        Catch ex As Exception
            Throw BSExceptionHandler.GetBSException(ex, BSExceptionHandler.GetThisMethodName)
        End Try
    End Sub

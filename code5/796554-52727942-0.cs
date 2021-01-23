    Private Sub Frmmain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For Each ctl As Control In Me.Controls
                If TypeOf ctl Is MdiClient Then
                    ctl.BackgroundImage = Me.BackgroundImage
                End If
            Next ctl
            Me.BackgroundImageLayout = ImageLayout.Zoom
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Frmmain_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Try
            Me.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

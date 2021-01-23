    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
    End Sub
    Private Sub Form1_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
        If WindowState = FormWindowState.Normal Then
            Me.Size = New Size(iWidth, iHeight)
        End If
    End Sub

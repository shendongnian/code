    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs)
	Dim c As Integer = 0
	If e.KeyCode = Keys.Tab Then
		Dim txtRun As New TextBox()
		txtRun.Name = "txtDynamic" & System.Math.Max(System.Threading.Interlocked.Increment(c),c - 1)
		'name
		txtRun.Location = New System.Drawing.Point(20, 18 + (20 * c))
		' Location of new control
		txtRun.Size = New System.Drawing.Size(200, 25)
		' size
		Me.Controls.Add(txtRun)
	End If
    End Sub

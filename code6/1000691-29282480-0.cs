    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim MyThread As New Threading.Thread(AddressOf ShowMyFolderBrowserDialog)
            MyThread.SetApartmentState(Threading.ApartmentState.STA)
            MyThread.Start()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Setup")
        End Try
    End Sub
    Private Sub ShowMyFolderBrowserDialog()
        Try
            Me.FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer
            Me.FolderBrowserDialog1.Description = "Select folder"
            If System.IO.Directory.Exists(Me.TextBox1.Text) Then
                Me.FolderBrowserDialog1.SelectedPath = Me.TextBox1.Text
            End If
            If Me.FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.TextBox1.Text = Me.FolderBrowserDialog1.SelectedPath
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Setup")
        End Try
    End Sub

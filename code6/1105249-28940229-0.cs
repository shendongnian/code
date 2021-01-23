    '   Yes, this is VB, translate it if you need to.  
    Private config1Images As List(Of Image) ...
    
    Private Sub commonButtonClickHandler(sender As Object, e As EventArgs) Handles ConfigButton1.Click, ConfigButton2.Click, ConfigButton3.Click
        Dim button As ToolStripButton = sender
        Dim imageIndex As Int32 = 0
    
        If button.Checked Then
            imageIndex = 1
        End If
    
        If ConfigButton1 Is button Then
            button1.Image = config1Images(imageIndex)
        End If
        '   etc.
    End Sub  

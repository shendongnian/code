    Private Sub ItalicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItalicToolStripMenuItem.Click
    
     If Not RichTextBox1.SelectionFont Is Nothing Then
    
                Dim currentFont As System.Drawing.Font = RichTextBox1.SelectionFont
                Dim newFontStyle As System.Drawing.FontStyle
    
                If RichTextBox1.SelectionFont.Italic = True Then
                    newFontStyle = FontStyle.Regular
                   
                    ItalicToolStripMenuItem.Checked = False
                Else
                    newFontStyle = FontStyle.Italic
                    
                    ItalicToolStripMenuItem.Checked = True
                End If
    
                RichTextBox1.SelectionFont = New Font(RichTextBox1.SelectionFont, RichTextBox1.SelectionFont.Style Xor FontStyle.Italic)
    
            End If
        End Sub

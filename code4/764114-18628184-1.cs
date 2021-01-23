    Public Class Form1
      Private Shared nt As Integer = 0
    
      Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tabPage As TabPage = New System.Windows.Forms.TabPage("newTab")
    
        Select Case nt
          Case 0
            If True Then
              tabPage.BackColor = Color.LightCoral
              tabPage.ImageIndex = 0
              nt = 1
            End If
            Exit Select
    
          Case 1
            If True Then
              tabPage.BackColor = Color.LightGoldenrodYellow
              tabPage.ImageIndex = 1
              nt = 2
            End If
            Exit Select
    
          Case 2
            If True Then
              tabPage.BackColor = Color.LightSeaGreen
              tabPage.ImageIndex = 2
              nt = 0
            End If
            Exit Select
        End Select
    
        tabControl1.TabPages.Add(tabPage)
      End Sub
    
      Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex)
      End Sub
    End Class

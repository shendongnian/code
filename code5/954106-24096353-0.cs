    Public Class Formtest1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not IsNothing(Formtest2) Then
            Formtest2.TextBox1.Text = Me.TextBox1.Text
            If Formtest2.Visible = False Then
                Formtest2.Show()
            Else
                Formtest2.Focus()
            End If
        End If
    End Sub
    End Class

    Public Class Form1
 
       Dim comRef As Microsoft.Office.Interop.Outlook.Application
       Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
          Dim t As New System.Threading.Thread(AddressOf CreateApplication)
          t.SetApartmentState(Threading.ApartmentState.STA)
          t.Start()
       End Sub
       Private Sub CreateApplication()
          comRef = New Microsoft.Office.Interop.Outlook.Application
       End Sub 
       Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
          TextBox1.Text = comRef.DefaultProfileName
       End Sub
    End Class

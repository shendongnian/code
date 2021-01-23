    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim loc As Point = PictureBox1.PointToClient(Button1.PointToScreen(Point.Empty))
      Button1.Parent = PictureBox1
      Button1.Location = loc
      Form2.Owner = Me
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      Form2.Show()
    End Sub
    Private Sub pictureBox1_LocationChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PictureBox1.LocationChanged
      Dim p As Point = button1.PointToScreen(Point.Empty)
      p.Offset(-Form2.Width/2, -Form2.Height-10)
      Form2.Location = p
    
    End Sub
    

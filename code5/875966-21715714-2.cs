    Private bitmap_monimo As Bitmap
    Private bitmap_temporary As Bitmap
    Private objGraphics As Graphics
    Private mouse_down As Point
    Private my_pen As Pen
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        my_pen = New Pen(Color.Black, 1)
        bitmap_monimo = New Bitmap(Panel1.ClientRectangle.Width, Panel1.ClientRectangle.Height, Drawing.Imaging.PixelFormat.Format24bppRgb)
        bitmap_temporary = New Bitmap(Panel1.ClientRectangle.Width, Panel1.ClientRectangle.Height, Drawing.Imaging.PixelFormat.Format24bppRgb)
        
        Call InitializeSurface()
        
    End Sub
    Private Sub InitializeSurface()
        objGraphics = Graphics.FromImage(bitmap_monimo)
        objGraphics.Clear(Panel1.BackColor)
        objGraphics = Graphics.FromImage(bitmap_temporary)
        objGraphics.Clear(Panel1.BackColor)
    End Sub
    Private Sub Panel1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = MouseButtons.Left Then
            bitmap_temporary = bitmap_monimo.Clone()
            objGraphics = Graphics.FromImage(bitmap_temporary)
            objGraphics.DrawEllipse(my_pen, mouse_down.X, mouse_down.Y, e.X - mouse_down.X, e.Y - mouse_down.Y)
            objGraphics.Dispose()
            objGraphics = Panel1.CreateGraphics
            objGraphics.DrawImage(bitmap_temporary, 0, 0, Panel1.Width, Panel1.Height)
            objGraphics.Dispose()
        End If
    End Sub
    Private Sub Panel1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        mouse_down.X = e.X
        mouse_down.Y = e.Y
    End Sub
    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        e.Graphics.DrawImage(bitmap_temporary, 0, 0, Panel1.Width, Panel1.Height)
    End Sub
    Private Sub Panel1_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        objGraphics = Graphics.FromImage(bitmap_monimo)
        objGraphics.DrawImage(bitmap_temporary, 0, 0, Panel1.Width, Panel1.Height)
        objGraphics.Dispose()
    End Sub

        e.Graphics.DrawString(Me.txtHeaderDescription, New Font("Calibri", 12, FontStyle.Italic), Brushes.White, New Point(105, 15))
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Near
        Dim Rectf As RectangleF = New Rectangle(105, 35, 200, 75)
        e.Graphics.DrawString(Me.txtDescription, New Font("Calibri", 8, FontStyle.Regular), Brushes.White, Rectf, sf)
        e.Graphics.DrawImage(Me.MyImage, 5, 3, 96, 96)

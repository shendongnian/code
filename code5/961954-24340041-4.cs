        Private Function OpenImageWithoutLockingIt(imagePath As String) As Bitmap
        If IO.File.Exists(imagePath) = False Then Return Nothing
        Using imfTemp As Image = Image.FromFile(imagePath)
            Dim MemImage As Bitmap = New Bitmap(imfTemp.Width, imfTemp.Height)
            Using g As Graphics = Graphics.FromImage(MemImage)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                g.Clear(Color.Transparent)
                g.DrawImage(imfTemp, 0, 0, MemImage.Width, MemImage.Height)
                Return MemImage
            End Using
        End Using
    End Function

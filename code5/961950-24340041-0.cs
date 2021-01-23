        Private Function OpenImageWithoutLockingIt(imagePath As String) As Bitmap
        Dim MemImage As Bitmap
        Using imfTemp As Image = Image.FromFile(imagePath)
            MemImage = New Bitmap(imfTemp.Width, imfTemp.Height)
            Using g As Graphics = Graphics.FromImage(MemImage)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                g.Clear(Color.Transparent)
                g.DrawImage(imfTemp, 0, 0, MemImage.Width, MemImage.Height)
            End Using
        End Using
        Return MemImage
    End Function

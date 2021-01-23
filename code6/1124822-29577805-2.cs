    ''' <summary>
    ''' Transforms an image to black and white.
    ''' </summary>
    ''' <param name="img">The image.</param>
    ''' <returns>The black and white image.</returns>
    Public Shared Function GetBlackAndWhiteImage(ByVal img As Image) As Image
        Dim bmp As Bitmap = New Bitmap(img.Width, img.Height)
        Dim grayMatrix As New System.Drawing.Imaging.ColorMatrix(
            {
                New Single() {0.299F, 0.299F, 0.299F, 0, 0},
                New Single() {0.587F, 0.587F, 0.587F, 0, 0},
                New Single() {0.114F, 0.114F, 0.114F, 0, 0},
                New Single() {0, 0, 0, 1, 0},
                New Single() {0, 0, 0, 0, 1}
            })
        Using g As Graphics = Graphics.FromImage(bmp)
            Using ia As System.Drawing.Imaging.ImageAttributes = New System.Drawing.Imaging.ImageAttributes()
                ia.SetColorMatrix(grayMatrix)
                ia.SetThreshold(0.5)
                g.DrawImage(img, New Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height,
                                                 GraphicsUnit.Pixel, ia)
            End Using
        End Using
        Return bmp
    End Function

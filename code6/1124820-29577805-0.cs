    ''' <summary>
    ''' Transforms an image to black and white.
    ''' </summary>
    ''' <param name="Image">The image.</param>
    ''' <returns>The black and white image.</returns>
    Public Shared Function GetBlackAndWhiteImage(ByVal Image As Image) As Bitmap
        Dim bmp As Bitmap = New Bitmap(Image.Width, Image.Height)
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
                ia.SetThreshold(0.8)
                g.DrawImage(Image, New Rectangle(0, 0, Image.Width, Image.Height), 0, 0, Image.Width, Image.Height,
                                                 GraphicsUnit.Pixel, ia)
            End Using
        End Using
        Return bmp
    End Function

    ''' <summary>
    ''' Adds a watermark into an image.
    ''' </summary>
    ''' <param name="img">Indicates the image.</param>
    ''' <param name="text">Indicates the watermark text.</param>
    ''' <param name="fnt">Indicates the watermark text Font.</param>
    ''' <param name="brush">Indicates the Brush used to paint the atermark text.</param>
    ''' <param name="position">Indicates the watermark text position.</param>
    ''' <param name="textformat">Indicates the watermark text format.</param>
    ''' <returns>Aspose.Imaging.Image.</returns>
    Private Function AddWatermark(ByVal img As Aspose.Imaging.Image,
                                  ByVal text As String,
                                  ByVal fnt As Aspose.Imaging.Font,
                                  ByVal brush As Aspose.Imaging.Brushes.SolidBrush,
                                  ByVal position As Aspose.Imaging.PointF,
                                  Optional ByVal textformat As Aspose.Imaging.StringFormat = Nothing) As Aspose.Imaging.Image
        ' Create and initialize an instance of Graphics class.
        Dim g As New Aspose.Imaging.Graphics(img)
        ' Draw a String using the SolidBrush object and Font, at specific Point and with specific format.
        g.DrawString(s:=text, font:=fnt, brush:=brush, 
                     point:=position, format:=textformat)
        ' Return the modified image.
        Return img
    End Function

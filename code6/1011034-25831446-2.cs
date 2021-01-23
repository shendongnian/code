    ''' <summary>
    ''' Adds a watermark into an image, at the specified position.
    ''' </summary>
    ''' <param name="img">Indicates the image.</param>
    ''' <param name="text">Indicates the watermark text.</param>
    ''' <param name="fnt">Indicates the watermark text font.</param>
    ''' <param name="color">Indicates the watermark text color.</param>
    ''' <param name="position">Indicates the watermark text position.</param>
    ''' <returns>Aspose.Imaging.Image.</returns>
    Private Function AddWatermark(ByVal img As Aspose.Imaging.Image,
                                  ByVal text As String,
                                  ByVal fnt As Aspose.Imaging.Font,
                                  ByVal color As Aspose.Imaging.Color,
                                  ByVal position As Aspose.Imaging.PointF) As Aspose.Imaging.Image
        Using brush As New Aspose.Imaging.Brushes.SolidBrush With {.Color = color, .Opacity = 100.0F}
            ' Create and initialize an instance of Graphics class.
            Dim g As New Aspose.Imaging.Graphics(img)
            ' Draw a String using the SolidBrush object and Font, at specific Point and with specific format.
            g.DrawString(s:=text, font:=fnt, brush:=brush, point:=position)
        End Using
        ' Return the modified image.
        Return img
    End Function
    ''' <summary>
    ''' Adds a watermark into an imag, at a prefedined position.
    ''' </summary>
    ''' <param name="img">Indicates the image.</param>
    ''' <param name="text">Indicates the watermark text.</param>
    ''' <param name="fnt">Indicates the watermark text font.</param>
    ''' <param name="color">Indicates the watermark text color.</param>
    ''' <param name="position">Indicates the watermark text position.</param>
    ''' <param name="verticalmargin">Indicates the watermark text vertical margin.</param>
    ''' <param name="horizontalmargin">Indicates the watermark text horizontal margin.</param>
    ''' <returns>Aspose.Imaging.Image.</returns>
    Private Function AddWatermark(ByVal img As Aspose.Imaging.Image,
                                  ByVal text As String,
                                  ByVal fnt As Aspose.Imaging.Font,
                                  ByVal color As Aspose.Imaging.Color,
                                  ByVal position As WatermarkPosition,
                                  Optional ByVal verticalmargin As Single = 0.0F,
                                  Optional ByVal horizontalmargin As Single = 0.0F) As Aspose.Imaging.Image
        Dim textformat As New Aspose.Imaging.StringFormat
        Dim textposition As Aspose.Imaging.PointF = Aspose.Imaging.PointF.Empty
        Select Case position
            Case WatermarkPosition.Top ' Note: horizontalmargin value is ignored.
                textposition = New Aspose.Imaging.PointF(x:=(img.Width \ 2), y:=verticalmargin)
                textformat.Alignment = Aspose.Imaging.StringAlignment.Center
                textformat.FormatFlags = Aspose.Imaging.StringFormatFlags.MeasureTrailingSpaces
            Case WatermarkPosition.TopLeft
                textposition = New Aspose.Imaging.PointF(x:=horizontalmargin, y:=verticalmargin)
                textformat.Alignment = Aspose.Imaging.StringAlignment.Near
                textformat.FormatFlags = Aspose.Imaging.StringFormatFlags.MeasureTrailingSpaces
            Case WatermarkPosition.TopRight
                Dim f As New System.Drawing.Font(fnt.Name, fnt.Size, DirectCast(fnt.Style, System.Drawing.FontStyle))
                Dim measure As System.Drawing.Size = TextRenderer.MeasureText(text, f)
                textposition = New Aspose.Imaging.PointF(x:=(img.Width - measure.Width - horizontalmargin), y:=verticalmargin)
                textformat.Alignment = Aspose.Imaging.StringAlignment.Near
                textformat.FormatFlags = Aspose.Imaging.StringFormatFlags.MeasureTrailingSpaces
            Case WatermarkPosition.Middle ' Note: verticalmargin horizontalmargin and values are ignored.
                textposition = New Aspose.Imaging.PointF(x:=(img.Width \ 2), y:=(img.Height \ 2))
                textformat.Alignment = Aspose.Imaging.StringAlignment.Center
                textformat.FormatFlags = Aspose.Imaging.StringFormatFlags.MeasureTrailingSpaces
            Case WatermarkPosition.MiddleLeft ' Note: verticalmargin value is ignored.
                textposition = New Aspose.Imaging.PointF(x:=(horizontalmargin), y:=(img.Height \ 2))
                textformat.Alignment = Aspose.Imaging.StringAlignment.Near
                textformat.FormatFlags = Aspose.Imaging.StringFormatFlags.MeasureTrailingSpaces
            Case WatermarkPosition.MiddleRight ' Note: verticalmargin value is ignored.
                Dim f As New System.Drawing.Font(fnt.Name, fnt.Size, DirectCast(fnt.Style, System.Drawing.FontStyle))
                Dim measure As System.Drawing.Size = TextRenderer.MeasureText(text, f)
                textposition = New Aspose.Imaging.PointF(x:=(img.Width - measure.Width - horizontalmargin), y:=(img.Height \ 2))
                textformat.Alignment = Aspose.Imaging.StringAlignment.Near
                textformat.FormatFlags = Aspose.Imaging.StringFormatFlags.MeasureTrailingSpaces
            Case WatermarkPosition.Bottom ' Note: horizontalmargin value is ignored.
                Dim f As New System.Drawing.Font(fnt.Name, fnt.Size, DirectCast(fnt.Style, System.Drawing.FontStyle))
                Dim measure As System.Drawing.Size = TextRenderer.MeasureText(text, f)
                textposition = New Aspose.Imaging.PointF(x:=(img.Width \ 2), y:=(img.Height - measure.Height - verticalmargin))
                textformat.Alignment = Aspose.Imaging.StringAlignment.Center
                textformat.FormatFlags = Aspose.Imaging.StringFormatFlags.MeasureTrailingSpaces
            Case WatermarkPosition.BottomLeft
                Dim f As New System.Drawing.Font(fnt.Name, fnt.Size, DirectCast(fnt.Style, System.Drawing.FontStyle))
                Dim measure As System.Drawing.Size = TextRenderer.MeasureText(text, f)
                textposition = New Aspose.Imaging.PointF(x:=(horizontalmargin), y:=(img.Height - measure.Height - verticalmargin))
                textformat.Alignment = Aspose.Imaging.StringAlignment.Near
                textformat.FormatFlags = Aspose.Imaging.StringFormatFlags.MeasureTrailingSpaces
            Case WatermarkPosition.BottomRight
                Dim f As New System.Drawing.Font(fnt.Name, fnt.Size, DirectCast(fnt.Style, System.Drawing.FontStyle))
                Dim measure As System.Drawing.Size = TextRenderer.MeasureText(text, f)
                textposition = New Aspose.Imaging.PointF(x:=(img.Width - measure.Width - horizontalmargin), y:=(img.Height - measure.Height - verticalmargin))
                textformat.Alignment = Aspose.Imaging.StringAlignment.Near
                textformat.FormatFlags = Aspose.Imaging.StringFormatFlags.MeasureTrailingSpaces
        End Select
        Using brush As New Aspose.Imaging.Brushes.SolidBrush With {.Color = color, .Opacity = 100.0F}
            ' Create and initialize an instance of Graphics class.
            Dim g As New Aspose.Imaging.Graphics(img)
            ' Draw a String using the SolidBrush object and Font, at specific Point and with specific format.
            g.DrawString(s:=text, font:=fnt, brush:=brush, point:=textposition, format:=textformat)
        End Using
        textformat.Dispose()
        ' Return the modified image.
        Return img
    End Function
    ''' <summary>
    ''' Specifies a Watermark position
    ''' </summary>
    Public Enum WatermarkPosition As Short
        ''' <summary>
        ''' Top position.
        ''' horizontalmargin value is ignored.
        ''' </summary>
        Top = 0S
        ''' <summary>
        ''' Top-Left position.
        ''' </summary>
        TopLeft = 1S
        ''' <summary>
        ''' Top-Right position.
        ''' </summary>
        TopRight = 2S
        ''' <summary>
        ''' Middle-Left position.
        ''' verticalmargin value is ignored.
        ''' </summary>
        MiddleLeft = 3S
        ''' <summary>
        ''' Middle position.
        ''' verticalmargin and horizontalmargin values are ignored.
        ''' </summary>
        Middle = 4S
        ''' <summary>
        ''' Middle-Right position.
        ''' verticalmargin value is ignored.
        ''' </summary>
        MiddleRight = 5S
        ''' <summary>
        ''' Bottom position.
        ''' horizontalmargin value is ignored.
        ''' </summary>
        Bottom = 6S
        ''' <summary>
        ''' Bottom-Left position.
        ''' </summary>
        BottomLeft = 7S
        ''' <summary>
        ''' Bottom-Right position.
        ''' </summary>
        BottomRight = 8S
    End Enum

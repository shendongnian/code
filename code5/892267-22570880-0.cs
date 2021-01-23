    Public Function GetSignaturePNG() As System.Drawing.Image
        'jSignature conversion from base30 to SVG            
        Dim base30Converter As New jSignature.Tools.Base30Converter()
        Dim arrBase30Data As Integer()()() = base30Converter.GetData(Me.SigBase30) 'our original base30 string
        Dim strSVG As String = jSignature.Tools.SVGConverter.ToSVG(arrBase30Data)
        'first convert it to SVG
        Dim mySVG As SvgDocument
        Dim newStream As New System.IO.MemoryStream(System.Text.ASCIIEncoding.[Default].GetBytes(strSVG))
        mySVG = SvgDocument.Open(newStream, Nothing)       
        
        'then convert it to PNG
        Dim tempStream As New System.IO.MemoryStream()
        mySVG.Draw().Save(tempStream, System.Drawing.Imaging.ImageFormat.Png)
        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(tempStream)
        Return img
    End Function

    'Create an instance of Image and load an existing image
    Using image As Aspose.Imaging.Image = Aspose.Imaging.Image.Load("c://temp//sample.bmp")
    	'Create and initialize an instance of the Graphics class
    	Dim graphics As New Aspose.Imaging.Graphics(image)
    	'Creates an instance of Font
    	Dim font As New Aspose.Imaging.Font("Times New Roman", 16, Aspose.Imaging.FontStyle.Bold)
    
    	'Create an instance of SolidBrush and set its various properties
    	Dim brush As New Aspose.Imaging.Brushes.SolidBrush()
    	brush.Color = Aspose.Imaging.Color.Black
    	brush.Opacity = 100
    
    	'Draw a String using the SolidBrush object and Font, at specific Point
    	graphics.DrawString("Aspose.Imaging for .Net", font, brush, New Aspose.Imaging.PointF(image.Width/2, image.Height/2))
    
    	' Export to PNG file format using default options.
    	image.Save("out.bmp",New Aspose.Imaging.ImageOptions.PngOptions())
    End Using

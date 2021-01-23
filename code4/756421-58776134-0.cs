        Private Function MakeTexture(ByVal b As Bitmap) As Texture2D
            Using MemoryStream As New MemoryStream
                b.Save(MemoryStream, System.Drawing.Imaging.ImageFormat.Png)
                Return Texture2D.FromStream(XNAGraphics.GraphicsDevice, MemoryStream)
            End Using
        End Function

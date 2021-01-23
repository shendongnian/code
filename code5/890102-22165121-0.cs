    static public int UploadTexture(string pathname)
    {
        // Create a new OpenGL texture object
        int id = GL.GenTexture();
    
        // Select the new texture
        GL.BindTexture(TextureTarget.Texture2D, id);
    
        // Load the image
        Bitmap bmp = new Bitmap(pathname);
    		 
        // Lock image data to allow direct access
        BitmapData bmp_data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    
        // Import the image data into the OpenGL texture
        GL.TexImage2D(TextureTarget.Texture2D,
                      0,
                      PixelInternalFormat.Rgba,
                      bmp_data.Width,
                      bmp_data.Height,
                      0,
                      OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                      OpenTK.Graphics.OpenGL.PixelType.UnsignedByte,
                      bmp_data.Scan0);
    
        // Unlock the image data
        bmp.UnlockBits(bmp_data);
    
        // Configure minification and magnification filters
        GL.TexParameter(TextureTarget.Texture2D,
                TextureParameterName.TextureMinFilter,
                (int)TextureMinFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D,
                TextureParameterName.TextureMagFilter,
                (int)TextureMagFilter.Linear);
    
        // Return the OpenGL object ID for use
        return id;
    }

     Byte[] image=(Byte[])(reader["Can_Pic"]); 
        
        if (image.Length == 0)
        {
            Picture.Image = null;
        }
        else
        {
            MemoryStream stream = new MemoryStream();
            stream.Write(image, 0, image.Length);
            Picture.Image = new Bitmap(stream);
        }

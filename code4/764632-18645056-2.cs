        string path = "Path to image";
        Bitmap bmp;//To validate the Image.
        try
        {
            bmp = new Bitmap(path);//Create a Bitmap object from the given path.
            if (bmp != null)
            {
                pictureBox1.Load(path);//Display the image to the user.
                //Now it's safe to store the image path in the database,
                //because we have validated it.
                bmp.Dispose();//Dispose the Bitmap object to free occupied resources.
                //Place you database related code here which uses the path we just validated.
            }
            else if (bmp == null)
            {
                //Show error image in PictureBox. 
                //(pictureBox1.Image="Path to error image").
                //Don't store image path,its invalid.
            }
        }
        catch (ArgumentException)
        {
            MessageBox.Show("The specified image file is invalid.");
        }
        catch (FileNotFoundException)
        {
            MessageBox.Show("The path to image is invalid.");
        }

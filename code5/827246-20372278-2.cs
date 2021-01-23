    //Load an image in from a file
    Image image = new Bitmap("Picture.png");
    //Set our picture box to that image
    pictureBox.Image = (Bitmap)image.Clone();
    
    //Store our old image so we can delete it
    Image oldImage = pictureBox.Image;
    //Pass in our original image and return a new image rotated 35 degrees right
    pictureBox.Image = Utilities.RotateImage(image, 35);
    if (oldImage != null)
    {
        oldImage.Dispose();
    } 

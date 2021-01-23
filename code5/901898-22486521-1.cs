    private Bitmap RandomImageSelection()
    {
        Bitmap image;
        if (randomGenerator.Next(2) == 0 && !line1.TryDequeue(out image))
        {
            line2.TryDequeue(out image)
        }
        if (image != null) 
        {
            pictureBox3.Invoke(new Action(() => pictureBox3.Image = image));
        }
        return image;
    }

    var bytes = from p in context.Products
                            where p.ID == value // Id of product that i want 
                            select p.Picture;
    byte[] trueBytes = bytes.ToArray();
    if (trueBytes != null)
    {
        using (var ms = new MemoryStream(trueBytes))
        {
            using (var image = Image.FromStream(ms))
            {
                pictureBox1.Image = (Image)image.Clone();
            }
        }
    }

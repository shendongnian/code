    var bytes = context.Products.FirstOrDefault(p => p.ID == value);
    if (bytes != null)
    {
         using (var ms = new MemoryStream(bytes)) 
         {
             using(var image = Image.FromStream(ms)) 
             {
                 pictureBox1.Image = (Image)image.Clone();
             }
         }
    }

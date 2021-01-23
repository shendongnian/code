    public static class MyExtensions
    {
        public static PictureBox CreateNewWithAttributes(this PictureBox pb)
        {
            return new PictureBox { Image = pb.Image, Width = pb.Width };
        }
    }
    Picturebox p2 = p1.CreateNewWithAttributes();
    this.Controls.Add(p2);

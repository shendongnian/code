    using(Bitmap source = ...)
    using(Bitmap destination = new Bitmap(1000, 1000))
    using(Graphics g = Graphics.FromImage(newImg)) {
        g.InterpolationMode = InterpolationMode.NearestNeighbor;
        g.DrawImage( source, new Rectangle( 0, 0, destination.Width, destination.Height ) );
    }

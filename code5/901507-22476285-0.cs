    foreach (Point p in points)
    {
        foreach (PictureBox pbb in pics)
        {
            if (pbb.Location == p)
            {
                pbb.Parent = this;
                pbb.Location = draw;
                Console.WriteLine(pics.Count());
            }
        }
    }

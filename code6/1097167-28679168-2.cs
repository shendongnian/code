    static bool IntersectPixels(Bitmap bmpA, Bitmap bmpB)
    {
         return IntersectPixels(new Rectangle(Point.Empty, bmpA.Size), bmpA,
                                new Rectangle(Point.Empty, bmpB.Size), bmpB);
    }

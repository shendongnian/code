    using (var b = new Bitmap()) {            // This is your canvas
        Graphics g = Graphics.FromImage(b);   // This is your graphics context
        g.DrawImage(Image.FromFile("a.png"),
                    new Rectangle(30, 30, 10, 10), 10, 10, 20, 20);
        // Do something with b (e.g. b.Save(…))
    }

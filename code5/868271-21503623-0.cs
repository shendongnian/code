    using (var sf = new StringFormat()
    {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center,
    })
    {
        progressBar1.CreateGraphics()
            .DrawString(message,
                new Font("Arial",
                    (float) 20, FontStyle.Regular),
                Brushes.Black,
                new Rectangle(0, 0, 600, 480), sf);
    }

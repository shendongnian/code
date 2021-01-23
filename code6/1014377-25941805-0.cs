    Size defaultSize = pictureBox1.Size;
    Size temp = defaultSize;
    for (int w = defaultSize.Width; w > 0; w -= 2)
    {
        temp.Width = w;
        pictureBox1.Size = temp;
        pictureBox1.Refresh();   // may be optional
        Thread.Sleep(10);
    }
    for (int w = temp.Width; w < defaultSize.Width; w += 2)
    {
        temp.Width = w;
        pictureBox1.Size = temp;
        pictureBox1.Refresh();  // is necessary
        Thread.Sleep(10);
    }

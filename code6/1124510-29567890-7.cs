    colors.Add(Color.Brown);
    //..
    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
       Color cHit = ((Bitmap)this.BackgroundImage).GetPixel(e.X, e.Y);
        foreach (Color c in colors )
            if (cHit .ToArgb() == c.ToArgb())
            {
                // do things here
                Console.WriteLine("You have hit Rectangle no.: " + colors .IndexOf(c) + " with Color " + cHit.ToString());
            }

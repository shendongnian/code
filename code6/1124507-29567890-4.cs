    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        foreach (Rectangle r in rects)
            if (r.Contains(e.Location))
            {
                // do things here
                Console.WriteLine("You have hit Rectangle no.: " + rects.IndexOf(r));
            }
    }

    using (Graphics G = Graphics.FromImage(newbmp))
    using (Pen pen = new Pen(Color.Red, 8f) )
    {
        // rounded corners please!
        pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
        G.DrawRectangle(pen, yourRectangle);
        //..
    }

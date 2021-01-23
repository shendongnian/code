    myform.Paint += (o, e) => {
        Graphics g = e.Graphics;
        using (Pen selPen = new Pen(Color.Blue))
        {
            g.DrawRectangle(selPen, 10, 10, 50, 50);
        }
    };

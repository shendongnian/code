    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        using(Pen pen = new Pen(Color.Black))
        {
            e.Graphics.DrawLine(tpen, ...);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Size oldSize = this.Size;
        Size newSize = new Size(this.Width / 4,  this.Height / 4);
        Bitmap targetBmp = new Bitmap(newSize.Width, newSize.Height);
        this.Size = newSize;
        button1.Hide();
        this.DrawToBitmap(targetBmp, new Rectangle(Point.Empty, newSize));
        this.Size = oldSize;
        using (Graphics G = this.CreateGraphics()) 
        { 
            G.DrawImage(targetBmp, 0, 0); 
        }
        button1.Show();
    }

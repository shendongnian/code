    private void DrawString()
    {
        System.Drawing.Graphics pic = pictureBox1.CreateGraphics();
        string drawString = "Sample Text";
        System.Drawing.Font drawFont = new System.Drawing.Font(
            "Arial", 16);
        System.Drawing.SolidBrush drawBrush = new
            System.Drawing.SolidBrush(System.Drawing.Color.Black);
        float x = 150.0f;
        float y = 50.0f;
        pic.DrawString(drawString, drawFont, drawBrush, x, y);
        drawFont.Dispose();
        drawBrush.Dispose();
        pic.Dispose();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        DrawString();
    }
        

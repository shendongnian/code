    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            mmr = new Rectangle(e.X - pieceSize / 2, 
                                e.Y - pieceSize / 2, pieceSize, pieceSize);
            pictureBox1.Invalidate();  // trigger the painting
        }
    }

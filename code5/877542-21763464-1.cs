    bool positionBird = true;
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (PictureBox1.Location.X == Screen.PrimaryScreen.Bounds.Width)
        {
            positionBird = false;
            PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX); // picture flips only once when touches boundary
        }
        else if (PictureBox1.Location.X == 0)
        {
            positionBird = true;
            PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX); // picture flips only once when touches boundary
        }
        if(positionBird)
        {
            PictureBox1.Left += 1;
        }
        else
        {
            PictureBox1.Left += -1;
        }
    }

     private void button1_Click(object sender, EventArgs e)
            {
                pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Invalidate();
                Application.DoEvents();
            }

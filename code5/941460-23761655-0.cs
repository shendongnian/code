    private void PictureBoxes_Click(object sender, EventArgs e)
    {
       PictureBox p = (PictureBox)sender;
       if (jug == 1)
       {
          jug = 2;
          p.Image = (Image)cruz.Clone();
       }
       
       else
       {
          jug = 1;
          p.Image = (Image)circu.Clone();
       }
    }

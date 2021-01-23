     Color prevColor = Color.Black;
     public void pictureBox1_MouseEnter(object sender, EventArgs e)
     {
        prevColor = pictureBox1.BackColor;
        pictureBox1.BackColor = Color.Blue;
     }
    
     public void pictureBox1_MouseLeave(object sender, EventArgs e)
     {
         pictureBox1.BackColor = prevColor;
     }

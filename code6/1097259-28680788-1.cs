    private void timer1_Tick(object sender, EventArgs e)
    {
      this.SuspendLayout();
      pictureBox.Location = new Point(picust.Location.X + 10, picust.Location.Y);
      this.ResumeLayout();
    }

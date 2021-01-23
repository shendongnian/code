            Image digidashboard = new Bitmap(Properties.Resources.digidashboard);
            //using (Graphics g = ((PictureBox)pictureBoxDashboard).CreateGraphics())
            //{
            //    g.DrawString("80.00", this.Font, new SolidBrush(Color.Red), 3, 6);
            //    pictureBoxUnlock.Image = digidashboard;
            //    pictureBoxDashboard.Invalidate();
            //}
            Graphics g = Graphics.FromImage(digidashboard);
            g.DrawString("80.00", this.Font, new SolidBrush(Color.Red), 3, 6);
            pictureBoxDashboard.Image = digidashboard;

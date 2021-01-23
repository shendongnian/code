        if (random.Next(3) == schat)
        {
            using (Graphics graphics = pictureBox1.CreateGraphics())
            {
                graphics.DrawImage(Properties.Resources.Schat, ClientRectangle);
            }
            totalGold += 100.0; // NEW LINE
            MessageBox.Show("Hoera je hebt extra geld gevonden", "zoektocht");
            lblTotaalGeld.Text = Convert.ToString("€" + totalGold);
            btnZoektocht.Enabled = false;
        }

        private void HideShow(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
                pictureBox1.Visible = true;
            else if (e.KeyCode == Keys.H)
                pictureBox1.Visible = false;
        }

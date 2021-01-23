        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Text = "Left: " + e.X.ToString() + ", " + e.Y.ToString();
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.None)
            {
                this.Text = e.X.ToString() + ", " + e.Y.ToString();
            }   
        }

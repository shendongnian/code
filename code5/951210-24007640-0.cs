        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MessageBox.Show("Left");
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MessageBox.Show("Right");
            }    
        }

    private void menuItemBack_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MessageBox.Show("back item is clicked");
            }
            else
            {
                MessageBox.Show("I will come back.");
                //do your return things here.
            }
        }

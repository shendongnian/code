    private void o(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.O)
            {
                openFileDialog1.ShowDialog();
            }
               
            else if (e.KeyCode == Keys.P)
            {
                player.Play();
            }
        }

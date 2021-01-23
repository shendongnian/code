      private void control_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyData)
            {
                case Keys.W:
                    {
                       MessageBox.Show("you pressed w");
                        break;
                    }
                case Keys.B:
                    {
                       MessageBox.Show("you pressed b");
                        break;
                    }
                case Keys.F11:
                    {
                       MessageBox.Show("you pressed F11");
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
    }

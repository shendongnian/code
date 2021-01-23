    private void Save(string time)
        {
            using(StreamWriter write = new StreamWriter(path, true)){
                write.WriteLine(time);
            }
        }
    
    private void CheckForWinner()
            {
                foreach (Control control in tableLayoutPanel1.Controls)
                {
                    Label iconLabel = control as Label;
                    {
                        if(iconLabel != null)
                        {
                            if (iconLabel.ForeColor == iconLabel.BackColor)
                            {
                                return;
                            }
                        }
                    }
    
                }
                MessageBox.Show("You finished the game, your time was: " + timeLabel.Text);
                Save(timeLabel.Text);
                //Close(); is outcommented because I want to see if it works.
            }

    private void playerTimer_Tick(object sender, EventArgs e)
    {
        for (int i = 0; i < 6; i++)
        {
            if (PlayersActive[i])
            {
                Players[i].Move(randomNumber.Next(3,10));
                // if the edge of the picture touches the end of the screen.
                if (Players[i].Left + Players[i].Width >= this.Width)
                    MessageBox.Show("Congrats! Player" + i.ToString() + "won!");
            }
        }
        this.Invalidate();
    }

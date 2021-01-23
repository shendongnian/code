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
                
                //Players[i].Left is the X cordinates(The length) from the left side of the winform.
                //Players[i].Width is the width of the picture ofcourse :D.
                // if X cordinates + picture width is greater than or equal to screen width. YOU WON :D
            }
        }
        this.Invalidate();
    }

    private void gameSounds()
    {
        if (!keyPressed)
        {
            player2.Stop();
            player.PlayLooping();
        }
        else 
        {
            player.Stop();
            player2.PlayLooping();
        }
    }

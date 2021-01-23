    public void StartListeningAnswers()
    {
        try
        {
            while (player.status.Equals(PlayerStatus.Playing))
            {
                string answer = player.Input.ReadLine();
                if (string.IsNullOrEmpty( answer )) 
                    return;
            }
        }
        finally
        {
            player.status = PlayerStatus.Stopped;
        }
    }

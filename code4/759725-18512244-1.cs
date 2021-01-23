        if (userPlayer.Lives <= 0)
        {
            if (inGameScreenShowing == true)
            {
                inGameScreenShowing = false;
                gameOverScreenShowing = true;
                GameOverScreen(spriteBatch, gameTime);
            }
            else
            {
                if (delayTime > DateTime.Now)
                {
                    // Hide screen and reset lives
                }
            }
        }

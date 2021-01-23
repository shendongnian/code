    if (allVariable.fenetre_Niveau_1_Wolf_359 == true || allVariable.fenetreAfficherStats == true)
            {
                spriteBatch.Draw(allVariable.backgroundAntibug, new Rectangle(0, 0, 1600, 900), Color.White);
                // Only call GetTexture if a video is playing or paused
                if (player.State != MediaState.Stopped)
                    videoTexture = player.GetTexture();
                // Draw the video, if we have a texture to draw.
                if (videoTexture != null)
                {
                    spriteBatch.Draw(videoTexture, new Rectangle(0, 0, 1600, 900), Color.White);
                }
            }

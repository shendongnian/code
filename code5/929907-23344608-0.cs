        public void updateScores()
        {
            // loop through each array in the list
            for (int i = 0; i < list.Count(); i++)
            {
                string[] lineData = list[i];
                if (lineData[1] == difficulty)
                {
                    if (score > Convert.ToInt32(lineData[0]))
                    {
                        // if the score is higher than one of the saved highscores remove all lower score down one index
                        for (int j = list.Count() - 1; j > scoreIndex; j--)
                        {
                            // continue
                        }
                        break;
                    }
                }
            }
        }

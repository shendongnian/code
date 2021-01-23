    public int BerekenScore(int score)
        {
            if (steen1.aantalOgen == steen2.aantalOgen)
            {
                if (steen1.aantalOgen == 6)
                    score += 25;
                  else
                  if (steen1.aantalOgen == 3)
                      score = 0;
                    else score += 5;
            }
            return score;
        }
    public void Speel()
        {
            steen1.Dobbel();
            steen2.Dobbel();
        }

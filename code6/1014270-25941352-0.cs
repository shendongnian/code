    public void ReplaceHero(HeroStats hero,HeroStats new_Hero)
            {
                for (int i = 0; i < 5;i++ )
                    if (team.ElementAt(i).Equals(hero))
                    {
                        team.Remove(hero);
                        team.Add(new_Hero);
                    }
            }

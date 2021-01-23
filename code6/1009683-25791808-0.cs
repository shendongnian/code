    public void fitness(Team t)
    {
        int score;
        foreach(HeroStats hero in t.Heros)
        {
            DoStuffWithHero(hero);
        }
    }

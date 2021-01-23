    public Team createTeam(int seed)
    {
        int index=0;
        Team t = new Team();
        Random rnd = new Random(seed);
        int cap = allHeroes.Count;
        while (t.count() < 5)
        {
            index = rnd.Next(0, cap);
            t.Add(allHeroes.ElementAt(index));
        }
        return t;
    }

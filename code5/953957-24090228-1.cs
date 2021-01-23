    public void Add(Base input)
    {
        var repository = new Repository();
        repository.Add(input);
        repository.Save();
    }

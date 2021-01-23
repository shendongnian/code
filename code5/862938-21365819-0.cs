    public List<Customer> GetOlderThan(int minimumAge, bool lazy)
    {
        using(Repository<Customer> repo = RepositoryFactory.Create<Customer>(lazy))
        {
            return repo.Retrieve(c => c.Age >= minimumAge);
        }
    }

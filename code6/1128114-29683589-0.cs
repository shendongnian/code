    public IEnumerable<[Namespace]> GetPeople(IEnumerable<int> Ids)
    {
        return FindAll(m => Ids.Contains(m.Id)).ToList();
    }
    
    IEnumerable<[Namespace].Person> people = _myRepository.GetPeople(listOfIds);
